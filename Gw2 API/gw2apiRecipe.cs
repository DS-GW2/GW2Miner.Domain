using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace GW2Miner.Domain
{
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GW2APIRecipeType
    {
        Refinement,
        [EnumMember(Value = "RefinementEctoplasm")]
        Refinement_Ectoplasm,
        [EnumMember(Value = "RefinementObsidian")]
        Refinement_Obsidian,
        Component,
        Bulk,
        Bag,
        Dye,
        Potion,
        [EnumMember(Value = "UpgradeComponent")]
        Upgrade_Component,
        Inscription,
        Insignia,
        Consumable,
        Dessert,
        [EnumMember(Value = "IngredientCooking")]
        Cooking_Ingredient,
        Seasoning,
        Feast,
        Snack,
        Soup,
        Meal,
        Coat,
        Leggings,
        Gloves,
        Helm,
        //[EnumMember(Value = "HelmAquatic")]
        //Aquatic_Helm,
        Boots,
        Shoulders,
        Sword,
        Hammer,
        [EnumMember(Value = "LongBow")]
        Long_Bow,
        [EnumMember(Value = "ShortBow")]
        Short_Bow,
        Axe,
        Dagger,
        Greatsword,
        Mace,
        Pistol,
        Rifle,
        Scepter,
        Staff,
        Focus,
        Torch,
        Warhorn,
        Shield,
        [EnumMember(Value = "Harpoon")]
        Spear,
        [EnumMember(Value = "Speargun")]
        Harpoon_Gun,
        Trident,
        Amulet,
        Ring,
        [EnumMember(Value = "Earring")]
        Accessory,
        Backpack,
        Unknown
    }

    [DataContract][Flags]
    [JsonConverter(typeof(JsonFlagsEnumTypeConverter))]
    public enum GW2APIDisciplines
    {
        None = 0,
        [EnumMember]
        Huntsman = 0x01,
        [EnumMember]
        Artificer = 0x02,
        [EnumMember]
        Weaponsmith = 0x04,
        [EnumMember]
        Armorsmith = 0x08,
        [EnumMember]        
        Leatherworker = 0x010,
        [EnumMember]
        Tailor = 0x020,
        [EnumMember]
        Jeweler = 0x040,
        [EnumMember(Value = "Chef")]
        Cook = 0x080,
        [EnumMember(Value = "Mystic Forge")]
        Mystic_Forge = 0x0100
    }

    [DataContract][Flags]
    [JsonConverter(typeof(JsonFlagsEnumTypeConverter))]
    public enum GW2APIRecipeFlags
    {
        None = 0,
        [EnumMember(Value = "AutoLearned")]
        Auto_Learned = 0x01,
        [EnumMember(Value = "LearnedFromItem")]
        Learned_From_Item = 0x02
    }

    /// <summary>
    /// Serializes a single GW2 API Recipe
    /// </summary>
    /// <remarks>
    /// See: https://forum-en.guildwars2.com/forum/community/api/API-Documentation/first#post2028044
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2apiRecipe
    {
        public gw2apiRecipe()
        {
            MinCraftingCost = new RecipeCraftingCost();
            IngredientRecipes = new List<gw2dbRecipe>();
            Sales = new List<ItemBuySellListingItem>();
            TPLastUpdated = DateTime.MinValue;
        }

        [JsonProperty("recipe_id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public GW2APIRecipeType Type { get; set; }

        [JsonProperty("disciplines")]
        public GW2APIDisciplines DisciplineIds { get; set; }

        [JsonProperty("flags")]
        public GW2APIRecipeFlags Flags { get; set; }

        [JsonProperty("output_item_id")]
        public int CreatedDataId { get; set; }

        [JsonProperty("output_item_count")]
        public int Quantity { get; set; }

        [JsonProperty("min_rating")]
        public int Rating { get; set; }

        [JsonProperty("time_to_craft_ms")]
        public int CraftingTime { get; set; }

        [JsonProperty("vendor_value")]
        public int VendorPrice { get; set; }

        [JsonProperty("ingredients")]
        public List<gw2apiIngredient> Ingredients { get; set; }

        // Compatibility
        public string Name { get; set; }

        public List<gw2dbRecipe> IngredientRecipes { get; set; }

        public ObtainableMethods BestMethod { get; set; }

        public int CreatedItemAvailability { get; set; }

        public int CreatedItemMinSaleUnitPrice { get; set; }

        public float CreatedItemVendorBuyUnitPrice { get; set; }

        public int CreatedItemMinKarmaUnitPrice { get; set; }

        public float CreatedItemMinSkillPointsUnitPrice { get; set; }

        public int CreatedItemMaxBuyUnitPrice { get; set; }

        public RecipeCraftingCost MinCraftingCost { get; set; }

        public DateTime TPLastUpdated { get; set; }

        public DateTime CraftingCostLastUpdated { get; set; }

        public List<ItemBuySellListingItem> Sales { get; set; }

        public void Print(string indent)
        {
            Console.Write("{0}{1}x {2}({3})\t", indent, Quantity, Name, (CreatedItemAvailability == int.MaxValue ? "Max" : CreatedItemAvailability.ToString()));
            if (Quantity == 0) Debugger.Break();
            if (BestMethod == ObtainableMethods.Karma)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("KARMA VENDOR({0})", CreatedItemMinKarmaUnitPrice * Quantity);
            }
            else if (BestMethod == ObtainableMethods.SkillPoints)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("SKILLPOINT VENDOR({0})", CreatedItemMinSkillPointsUnitPrice * Quantity);
            }
            else if (BestMethod == ObtainableMethods.Unknown)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("NOT CRAFTED, NOT SOLD");
            }
            else
            {
                if (BestMethod == ObtainableMethods.Buy || BestMethod == ObtainableMethods.Vendor)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0}({1})", BestMethod == ObtainableMethods.Vendor ? "VENDOR" : "TP", (BestMethod == ObtainableMethods.Vendor ? CreatedItemVendorBuyUnitPrice : CreatedItemMinSaleUnitPrice) * Quantity);
                if (BestMethod == ObtainableMethods.Craft)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CRAFT({0})", MinCraftingCost.GoldCost);
            }
            Console.ResetColor();
            if (BestMethod == ObtainableMethods.Craft && IngredientRecipes != null && IngredientRecipes.Count > 0)
            {
                foreach (gw2dbRecipe ingredient in IngredientRecipes)
                {
                    ingredient.Print(indent + "  ");
                }
            }
        }

        public void ShoppingList(bool useQuantity = true)
        {
            Dictionary<int, ShoppingListItem> shoppingList = new Dictionary<int, ShoppingListItem>();

            GenerateShoppingList(shoppingList);

            foreach (ShoppingListItem item in shoppingList.Values)
            {
                Console.Write("{0}\t{1}\t", (useQuantity ? item.Quantity : item.Availability), item.Name);
                if (item.Method == ObtainableMethods.Unknown)
                {
                    Console.WriteLine();
                    continue;
                }
                else if (item.Method == ObtainableMethods.Karma)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (item.Method == ObtainableMethods.SkillPoints)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.WriteLine("{0}\t{1}", item.UnitPrice, item.UnitPrice * (useQuantity ? item.Quantity : item.Availability));
                Console.ResetColor();
            }
        }

        internal void GenerateShoppingList(Dictionary<int, ShoppingListItem> shoppingList)
        {
            if (BestMethod == ObtainableMethods.Craft && IngredientRecipes != null && IngredientRecipes.Count > 0)
            {
                foreach (gw2dbRecipe ingredient in IngredientRecipes)
                {
                    ingredient.CreatedItemAvailability = (int)Math.Floor((double)CreatedItemAvailability * ingredient.Quantity / Quantity);
                    ingredient.GenerateShoppingList(shoppingList);
                }
            }
            else
            {
                if (shoppingList.ContainsKey(CreatedDataId))
                {
                    shoppingList[CreatedDataId].Quantity += Quantity;
                    shoppingList[CreatedDataId].Availability += CreatedItemAvailability;
                }
                else
                {
                    ShoppingListItem shoppingItem = new ShoppingListItem();
                    shoppingItem.Name = Name;
                    shoppingItem.Quantity = Quantity;
                    shoppingItem.Availability = CreatedItemAvailability;
                    shoppingItem.Method = BestMethod;

                    switch (BestMethod)
                    {
                        case ObtainableMethods.Karma:
                            shoppingItem.UnitPrice = CreatedItemMinKarmaUnitPrice;
                            break;

                        case ObtainableMethods.SkillPoints:
                            shoppingItem.UnitPrice = CreatedItemMinSkillPointsUnitPrice;
                            break;

                        case ObtainableMethods.Buy:
                            shoppingItem.UnitPrice = CreatedItemMinSaleUnitPrice;
                            break;

                        case ObtainableMethods.Vendor:
                            shoppingItem.UnitPrice = CreatedItemVendorBuyUnitPrice;
                            break;
                    }

                    shoppingList.Add(CreatedDataId, shoppingItem);
                }
            }
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class gw2apiIngredient
    {
        [JsonProperty("item_id")]
        public int Id { get; set; }

        [JsonProperty("count")]
        public int Quantity { get; set; }
    }
}
