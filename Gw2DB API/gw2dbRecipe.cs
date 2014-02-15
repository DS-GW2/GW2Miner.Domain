using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GW2Miner.Domain
{
    public enum GW2DBDisciplines
    {
        Huntsman = 1,
        Artificer = 2,
        Weaponsmith = 3,
        Armorsmith = 4,
        Leatherworker = 5,
        Tailor = 6,
        Jeweler = 7,
        Cook = 8,
        Mystic_Forge = 9,
    }

    public enum ObtainableMethods
    {
        Buy,
        Craft,
        Vendor,
        Karma,
        SkillPoints,
        Unknown
    }

    /// <summary>
    /// Serializes a single GW2Spidy item
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2dbRecipe
    {
        public gw2dbRecipe()
        {
            MinCraftingCost = new RecipeCraftingCost();
            IngredientRecipes = new List<gw2dbRecipe>();
            TPLastUpdated = DateTime.MinValue;
            Sales = new List<ItemBuySellListingItem>();
        }

        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("DataID")]
        public int Data_Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public GW2DBDisciplines DisciplineId { get; set; }

        [JsonProperty("ExternalID")]
        public int GW2DBExternalId { get; set; }

        [JsonProperty("Rating")]
        public int Rating { get; set; }

        [JsonProperty("Count")]
        public int Quantity { get; set; }

        [JsonProperty("CreatedItemId")]
        public int CreatedItemId { get; set; }

        [JsonProperty("CreatedDataId")]
        public int CreatedDataId { get; set; }

        [JsonProperty("RequiresRecipeItem")]
        public bool RequiresRecipeItem { get; set; }

        [JsonProperty("Ingredients")]
        public List<gw2dbIngredient> Ingredients { get; set; }

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

        public gw2apiRecipe ToGw2ApiRecipe
        {
            get
            {
                gw2apiRecipe recipe = new gw2apiRecipe();
                recipe.Id = Data_Id;
                recipe.Name = Name;
                recipe.Rating = Rating;
                recipe.Quantity = Quantity;
                recipe.CreatedDataId = CreatedDataId;

                recipe.Ingredients = new List<gw2apiIngredient>();
                foreach (gw2dbIngredient ingredient in Ingredients)
                {
                    gw2apiIngredient apiIngredient = new gw2apiIngredient();
                    apiIngredient.Id = ingredient.Id;  // watch out for gw2db Id vs data Id
                    apiIngredient.Quantity = ingredient.Quantity;
                    recipe.Ingredients.Add(apiIngredient);
                }

                recipe.IngredientRecipes = IngredientRecipes;
                recipe.BestMethod = BestMethod;
                recipe.CreatedItemMinSaleUnitPrice = CreatedItemMinSaleUnitPrice;
                recipe.CreatedItemVendorBuyUnitPrice = CreatedItemVendorBuyUnitPrice;
                recipe.CreatedItemMinKarmaUnitPrice = CreatedItemMinKarmaUnitPrice;
                recipe.CreatedItemMinSkillPointsUnitPrice = CreatedItemMinSkillPointsUnitPrice;
                recipe.CreatedItemMaxBuyUnitPrice = CreatedItemMaxBuyUnitPrice;
                recipe.MinCraftingCost = MinCraftingCost;
                recipe.TPLastUpdated = TPLastUpdated;
                recipe.CraftingCostLastUpdated = CraftingCostLastUpdated;
                
                switch (DisciplineId)
                {
                    case GW2DBDisciplines.Armorsmith:
                        recipe.DisciplineIds |= GW2APIDisciplines.Armorsmith;
                        break;

                    case GW2DBDisciplines.Artificer:
                        recipe.DisciplineIds |= GW2APIDisciplines.Artificer;
                        break;

                    case GW2DBDisciplines.Cook:
                        recipe.DisciplineIds |= GW2APIDisciplines.Cook;
                        break;

                    case GW2DBDisciplines.Huntsman:
                        recipe.DisciplineIds |= GW2APIDisciplines.Huntsman;
                        break;

                    case GW2DBDisciplines.Jeweler:
                        recipe.DisciplineIds |= GW2APIDisciplines.Jeweler;
                        break;

                    case GW2DBDisciplines.Leatherworker:
                        recipe.DisciplineIds |= GW2APIDisciplines.Leatherworker;
                        break;

                    case GW2DBDisciplines.Tailor:
                        recipe.DisciplineIds |= GW2APIDisciplines.Tailor;
                        break;

                    case GW2DBDisciplines.Weaponsmith:
                        recipe.DisciplineIds |= GW2APIDisciplines.Weaponsmith;
                        break;

                    case GW2DBDisciplines.Mystic_Forge:
                        recipe.DisciplineIds |= GW2APIDisciplines.Mystic_Forge;
                        break;
                }

                return recipe;
            }
        }

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
    public class gw2dbIngredient
    {
        [JsonProperty("ItemID")]
        public int Id { get; set; }

        [JsonProperty("Count")]
        public int Quantity { get; set; }
    }

    public class RecipeCraftingCost
    {
        private int goldCost;
        private int karmaCost;
        private float skillPointsCost;
        private int createdItemAvailability;

        public int CreatedItemAvailability
        {
            get
            {
                return createdItemAvailability;
            }
            set
            {
                createdItemAvailability = value;
            }
        }

        public int GoldCost
        {
            get
            {
                return goldCost;
            }
            set
            {
                goldCost = value;
            }
        }

        public int KarmaCost
        {
            get
            {
                return karmaCost;
            }
            set
            {
                karmaCost = value;
            }
        }

        public float SkillPointsCost
        {
            get
            {
                return skillPointsCost;
            }
            set
            {
                skillPointsCost = value;
            }
        }
    }

    public class ShoppingListItem
    {
        public int Quantity;
        public string Name;
        public float UnitPrice;
        public ObtainableMethods Method;
        public int Availability;
    }
}
