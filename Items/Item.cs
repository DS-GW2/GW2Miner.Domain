using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace GW2Miner.Domain
{
    /// <summary>
    /// Serializes a single item
    /// </summary>
    /// <remarks>
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class Item
    {
        public Item()
        {
            IsRich = false;
            Margin = PercentProfit = -1.0;
            BoughtPrice = -2;
            Worth = -1;
            ProfitNow = Profit = int.MinValue;
            Created = DateTime.MinValue;
            Purchased = DateTime.MinValue;
        }

        [JsonProperty("data_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("rarity")]
        public RarityEnum RarityId { get; set; }
        
        [JsonProperty("rarity_word")]
        public string RarityDescription { get; set; }

        [JsonProperty("level")]
        public int MinLevel { get; set; }

        [JsonProperty("img")]
        public string ImageUri { get; set; }

        [JsonProperty("buy_price")] 
        public int MaxOfferUnitPrice { get; set; }

        [JsonProperty("buy_count")]
        public int BuyCount { get; set; }

        [JsonProperty("sell_price")]  // also known as "price" in sorting
        public int MinSaleUnitPrice { get; set; }

        [JsonProperty("sell_count")] // also known as "count" in sorting
        public int SellCount { get; set; }

        [JsonProperty("vendor")]
        public int VendorPrice { get; set; }

        #region GW2Spidy Compatibility
        // Just shows 3?
        // gw2spidy item compatibility
        [JsonProperty("type_id")]
        public TypeEnum TypeId { get; set; }

        // Not returned from ANet
        // gw2spidy item compatibility
        [JsonProperty("sub_type_id")]
        public int SubTypeId { get; set; }

        // gw2spidy item compatibility
        [JsonProperty("price_last_changed")]
        public string PriceLastChanged { get; set; }

        // gw2spidy item compatibility
        [JsonProperty("sale_price_change_last_hour")]
        public int SalePriceChangedLastHour { get; set; }

        // gw2spidy item compatibility
        [JsonProperty("offer_price_change_last_hour")]
        public int OfferPriceChangedLastHour { get; set; }

        // gw2spidy item compatibility
        [JsonProperty("gw2db_external_id")]
        public int GW2DBExternalId { get; set; }
        #endregion

        #region GW2DB Compatibility
        [JsonProperty("Defense")]
        public int Defense { get; set; }

        [JsonProperty("MinPower")]
        public int MinPower { get; set; }

        [JsonProperty("MaxPower")]
        public int MaxPower { get; set; }

        [JsonProperty("ArmorWeightType")]
        public GW2DBArmorWeightType ArmorWeightType { get; set; }

        [JsonProperty("Stats")]
        public List<gw2dbStat> Stats { get; set; }

        [JsonProperty("SoldBy")]
        public List<gw2dbSoldBy> SoldBy { get; set; }

        public List<gw2dbRecipe> Recipes { get; set; }

        public RecipeCraftingCost MinCraftingCost
        {
            get
            {
                if (this.Recipes.Count > 0)
                {
                    RecipeCraftingCost minRecipeCost = new RecipeCraftingCost { GoldCost = int.MaxValue, KarmaCost = int.MaxValue };
                    foreach (gw2dbRecipe recipe in this.Recipes)
                    {
                        if ((recipe.MinCraftingCost.GoldCost < minRecipeCost.GoldCost) ||
                            ((recipe.MinCraftingCost.GoldCost == minRecipeCost.GoldCost) && (recipe.MinCraftingCost.KarmaCost < minRecipeCost.KarmaCost)))
                        {
                            minRecipeCost = recipe.MinCraftingCost;
                        }
                    }
                    if (minRecipeCost.GoldCost == int.MaxValue)
                    {
                        minRecipeCost.GoldCost = minRecipeCost.KarmaCost = 0;
                    }
                    return minRecipeCost;
                }
                return null;
            }
        }
        #endregion

        #region GW2API Compatibility
        [JsonProperty("game_types")]
        public GW2APIGameTypeEnum GameType;

        [JsonProperty("flags")]
        public GW2APIFlagsEnum Flags;

        [JsonProperty("restrictions")]
        public GW2APIRestrictionsEnum Restrictions;

        [JsonProperty("suffix_item_id")]
        public int? UpgradeId { get; set; }

        [JsonProperty("damage_type")]
        public GW2APIWeaponDamageTypeEnum DamageType { get; set; }
        #endregion

        // Mark if this is a rich item or not
        public bool IsRich { get; set; }

        public bool HasGW2DBData { get; set; }

        #region Transactions Specific
        // Specific to my transactions
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        // Specific to my transactions
        [JsonProperty("purchased")]
        public DateTime Purchased { get; set; }

        // Specific to my transactions
        [JsonProperty("unit_price")]
        public int UnitPrice { get; set; }

        // Specific to my transactions
        [JsonProperty("fuzzy")]
        public string HowLongAgo { get; set; }

        // Specific to my transactions
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        // Specific to my transactions
        [JsonProperty("listing_id")]
        public long ListingId { get; set; }
        #endregion

        #region Cache Calculated Fields
        // Cache calculated fields
        public double Margin { get; set; }

        public double PercentProfit { get; set; }

        public int BoughtPrice { get; set; }

        public int Profit { get; set; }

        public int ProfitNow { get; set; }

        public int Worth { get; set; }

        public bool IAmSelling { get; set; }

        public bool sellUnderCut { get; set; }

        public Item myItemOnSale { get; set; }

        public string UpgradeName { get; set; }

        public string UpgradeDescription { get; set; }
        #endregion

        /// <summary>
        /// Checks if the provided object is equal to the current Item
        /// </summary>
        /// <param name="obj">Object to compare to the current Item</param>
        /// <returns>True if equal, false if not</returns>
        public override bool Equals(object obj)
        {
            // Try to cast the object to compare to to be an item
            var item = obj as Item;

            return Equals(item);
        }

        /// <summary>
        /// Returns an identifier for this instance
        /// </summary>
        public override int GetHashCode()
        {
            if (Purchased != DateTime.MinValue && Created != DateTime.MinValue) return Purchased.GetHashCode() & Created.GetHashCode();

            return Id.GetHashCode();
        }

        /// <summary>
        /// Checks if the provided Item is equal to the current Item
        /// </summary>
        /// <param name="personToCompareTo">Item to compare to the current Item</param>
        /// <returns>True if equal, false if not</returns>
        public bool Equals(Item itemToCompareTo)
        {
            // Check if item is being compared to a non item. In that case always return false.
            if (itemToCompareTo == null) return false;

            if (Purchased != DateTime.MinValue && Created != DateTime.MinValue) 
                return (Created == itemToCompareTo.Created && Purchased == itemToCompareTo.Purchased);

            // Check if both item objects contain the same Id. In that case they're assumed equal.
            return Id == itemToCompareTo.Id;
        }

        public void setConsoleColor()
        {
            switch (this.RarityId)
            {
                case RarityEnum.Fine:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case RarityEnum.Masterwork:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case RarityEnum.Rare:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case RarityEnum.Exotic:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case RarityEnum.Ascended:
                    Console.ForegroundColor = ConsoleColor.Magenta; // Pink
                    break;

                case RarityEnum.Legendary:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta; // Purple
                    //Console.Write("\033[35m");
                    break;

                default:
                    Console.ResetColor();
                    //Console.Write("\033[0m");
                    break;
            }
        }

        public Color GetItemColor()
        {
            switch (this.RarityId)
            {
                case RarityEnum.Fine:
                    return Color.Blue;

                case RarityEnum.Masterwork:
                    return Color.LightGreen;

                case RarityEnum.Rare:
                    return Color.Yellow;

                case RarityEnum.Exotic:
                    return Color.Orange;

                case RarityEnum.Ascended:
                    return Color.Pink;

                case RarityEnum.Legendary:
                    return Color.Purple;
                    //Console.Write("\033[35m");

                default:
                    return Color.White;
                    //Console.Write("\033[0m");
            }
        }

        public string SubTypeDescription
        {
            get
            {
                if (!this.IsRich && !this.HasGW2DBData) return this.SubTypeId.ToString().Replace("_", " ");

                switch (this.TypeId)
                {
                    case TypeEnum.Armor:
                        return ((ArmorSubTypeEnum)this.SubTypeId).ToString().Replace("_", " ");

                    case TypeEnum.Consumable:
                        return ((ConsumableSubTypeEnum)this.SubTypeId).ToString().Replace("_", " ");

                    case TypeEnum.Container:
                        return ((ContainerSubTypeEnum)this.SubTypeId).ToString().Replace("_", " ");

                    case TypeEnum.Gathering:
                        return ((GatheringSubTypeEnum)this.SubTypeId).ToString().Replace("_", " ");

                    case TypeEnum.Gizmo:
                        return ((GizmoSubTypeEnum)this.SubTypeId).ToString().Replace("_", " ");

                    case TypeEnum.Tool:
                        return ((ToolSubTypeEnum)this.SubTypeId).ToString().Replace("_", " ");

                    case TypeEnum.Trinket:
                        return ((TrinketSubTypeEnum)this.SubTypeId).ToString().Replace("_", " ");

                    case TypeEnum.Upgrade_Component:
                        return ((UpgradeComponentSubTypeEnum)this.SubTypeId).ToString().Replace("_", " ");

                    case TypeEnum.Weapon:
                        return ((WeaponSubTypeEnum)this.SubTypeId).ToString().Replace("_", " ");

                    default:
                        return this.SubTypeId.ToString().Replace("_", " ");
                }
            }
        }

        public string ToolTipString
        {
            get
            {
                if (HasGW2DBData)
                {
                    string tooltipString = String.Format("{0}\n", Name);

                    switch (TypeId)
                    {
                        case TypeEnum.Armor:
                            tooltipString = String.Format("{0}\nDefense:{1}\n{2}\n{3}\n{4}\n", tooltipString, Defense, StatsToolTipString,
                                    SubTypeDescription, ArmorWeightType.ToString());
                            break;

                        case TypeEnum.Back:
                            //tooltipString = String.Format("{0}\nDefense:{1}\n{2}\nBack\n", tooltipString, Defense, StatsToolTipString);
                            tooltipString = String.Format("{0}\n{1}\nBack\n", tooltipString, StatsToolTipString);
                            break;

                        case TypeEnum.Weapon:
                            if (Defense > 0)
                            {
                                tooltipString = String.Format("{0}\nWeapon Strength: {1} - {2}\nDefense:{3}\n{4}\n{5}\nDamage Type: {6}\n", tooltipString, MinPower, MaxPower,
                                        Defense, StatsToolTipString, SubTypeDescription, DamageType);
                            }
                            else
                            {
                                tooltipString = String.Format("{0}\nWeapon Strength: {1} - {2}\n{3}\n{4}\nDamage Type: {5}\n", tooltipString, MinPower, MaxPower,
                                        StatsToolTipString, SubTypeDescription, DamageType);
                            }
                            break;

                        case TypeEnum.Trinket:
                            tooltipString = String.Format("{0}\n{1}\n{2}\n", tooltipString, StatsToolTipString, SubTypeDescription);
                            break;

                        //case TypeEnum.Bag:
                        //case TypeEnum.Container:
                        //case TypeEnum.Mini:
                        case TypeEnum.Tool:
                        case TypeEnum.Crafting_Material:
                        case TypeEnum.Upgrade_Component:
                            tooltipString = String.Format("{0}\n{1}\n", tooltipString, Description);
                            break;

                        case TypeEnum.Consumable:
                        case TypeEnum.Gathering:
                            tooltipString = String.Format("{0}\n{1}\n{2}\n", tooltipString, Description, SubTypeDescription);
                            break;

                        default:
                            return DefaultToolTipString;
                    }
                    if (UpgradeId != null)
                    {
                        tooltipString = String.Concat(tooltipString, String.Format("\n{0}\n{1}\n\n", UpgradeName, UpgradeDescription));
                    }
                    if (MinLevel > 0) tooltipString = String.Concat(tooltipString, String.Format("Required Level: {0}", MinLevel));
                    if ((Flags & (GW2APIFlagsEnum.Account_Bound | GW2APIFlagsEnum.SoulBound_On_Acquire | GW2APIFlagsEnum.SoulBound_On_Use 
                                    | GW2APIFlagsEnum.No_Sell | GW2APIFlagsEnum.No_Salvage | GW2APIFlagsEnum.No_Mystic_Forge | GW2APIFlagsEnum.Unique)) != 0)
                    {
                        tooltipString = String.Concat(tooltipString, String.Format("\n{0}", Flags.ToString().Replace("_", " ")));
                    }

                    return tooltipString;
                }
                else
                {
                    return DefaultToolTipString;
                }
            }
        }

        private string DefaultToolTipString
        {
            get
            {
                int tpSalePrice = (int)Math.Floor(MaxOfferUnitPrice * 0.85);
                string tooltipString = String.Format("{0}\nTP Sale Profit: {1}\nVendor Price: {2}\nMax Offer Unit Price: {3}\nMin Sale Unit Price: {4}\nOffer Availability: {5}\nSale Availability: {6}",
                                            Name, tpSalePrice, VendorPrice, MaxOfferUnitPrice, MinSaleUnitPrice,
                                            BuyCount, SellCount);
                if (MinLevel > 0)
                {
                    tooltipString = String.Concat(tooltipString, String.Format("\nRequired Level: {0}", MinLevel));
                }
                if (VendorPrice > tpSalePrice)
                {
                    tooltipString = String.Concat(tooltipString, "\nMore Profitable to sell to the Vendor than to the Trading Post!");
                }
                return tooltipString;
            }
        }

        private string StatsToolTipString
        {
            get
            {
                string tooltipString = String.Empty;
                if (HasGW2DBData)
                {
                    foreach (gw2dbStat stat in Stats)
                    {
                        tooltipString = String.Format("{0} +{1} {2}\n", tooltipString, (int)stat.Value, stat.Type.ToString().Replace("_", " "));
                    }
                }
                return tooltipString;
            }
        }
    }

    /// <summary>
    /// ItemComparer Class
    /// </summary>
    class ItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item item1, Item item2)
        {
            return item1.Id == item2.Id;
        }

        public int GetHashCode(Item item)
        {
            return item.Id;
        }
    }

}
