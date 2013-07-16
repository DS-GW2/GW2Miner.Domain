using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2Miner.Domain
{
    /// <summary>
    /// Serializes a single GW2Spidy item
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2spidyItem
    {
        [JsonProperty("data_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rarity")]
        public RarityEnum RarityId { get; set; }

        [JsonProperty("restriction_level")]
        public int MinLevel { get; set; }

        [JsonProperty("img")]
        public string ImageUri { get; set; }

        [JsonProperty("type_id")]
        public TypeEnum TypeId { get; set; }

        [JsonProperty("sub_type_id")]
        public int SubTypeId { get; set; }

        [JsonProperty("price_last_changed")]
        public string PriceLastChanged { get; set; }

        [JsonProperty("sale_price_change_last_hour")]
        public int SalePriceChangedLastHour { get; set; }

        [JsonProperty("offer_price_change_last_hour")]
        public int OfferPriceChangedLastHour { get; set; }

        [JsonProperty("gw2db_external_id")]
        public int GW2DBExternalId { get; set; }

        [JsonProperty("max_offer_unit_price")]
        public int MaxOfferUnitPrice { get; set; }

        [JsonProperty("offer_availability")]
        public int BuyCount { get; set; }

        [JsonProperty("min_sale_unit_price")]
        public int MinSaleUnitPrice { get; set; }

        [JsonProperty("sale_availability")]
        public int SellCount { get; set; }
    }
}
