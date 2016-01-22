using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2Miner.Domain
{
    /// <summary>
    /// Serializes the top level of the GW2Spidy item listing
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemBuySellListingList
    {
        [JsonProperty("listings")]
        public ItemBuySellListing Listings { get; set; }
    }

    /// <summary>
    /// Serializes the top level of the GW2Spidy item listing
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    //[JsonObject(MemberSerialization.OptIn)]
    //public class ItemBuySellListing
    //{
    //    [JsonProperty("sells")]
    //    public List<ItemBuySellListingItem> SellListings { get; set; }

    //    [JsonProperty("buys")]
    //    public List<ItemBuySellListingItem> BuyListings { get; set; }
    //}

    /// <summary>
    /// Serializes the top level of the GW2Spidy item listing
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemBuySellListing
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("sells")]
        public List<ItemBuySellListingItem> SellListings { get; set; }

        [JsonProperty("buys")]
        public List<ItemBuySellListingItem> BuyListings { get; set; }
    }
}
