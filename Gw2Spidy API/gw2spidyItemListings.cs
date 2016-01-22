using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2Miner.Domain
{
    /// <summary>
    /// Serializes the top level of the GW2Spidy item listings
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-item-listings
    /// </remarks>    
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2spidyItemListings
    {
        [JsonProperty("sell-or-buy")]
        public String SellOrBuy { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("last_page")]
        public int LastPage { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("results")]
        public List<gw2spidyItemListing> Listings { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class gw2spidyItemListing
    {
        [JsonProperty("listing_datetime")]
        public String ListingDateTimeString { get; set; }

        [JsonProperty("unit_price")]
        public int PricePerUnit { get; set; }

        [JsonProperty("quantity")]
        public int NumberAvailable { get; set; }

        [JsonProperty("listings")]
        public int NumberOfListings { get; set; }

        public DateTime ListingDateTime
        {
            get
            {
                // "2013-12-24 21:10:45 UTC"
                DateTime listingDT = DateTime.ParseExact(ListingDateTimeString, "yyyy-MM-dd HH:mm:ss UTC", new CultureInfo("", true), DateTimeStyles.AssumeUniversal);
                return listingDT;
            }
        }
    }
}
