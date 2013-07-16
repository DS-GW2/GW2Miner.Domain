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

        public int CreatedItemMinSaleUnitPrice { get; set; }

        public int CreatedItemVendorBuyUnitPrice { get; set; }

        public int CreatedItemMinKarmaUnitPrice { get; set; }

        public float CreatedItemMinSkillPointsUnitPrice { get; set; }

        public int CreatedItemMaxBuyUnitPrice { get; set; }

        public RecipeCraftingCost MinCraftingCost { get; set; }

        public DateTime TPLastUpdated { get; set; }

        public DateTime CraftingCostLastUpdated { get; set; }

        public void Print(string indent)
        {
            Console.Write("{0}{1}x {2}\t", indent, Quantity, Name);
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
}
