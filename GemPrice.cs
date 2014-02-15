using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2Miner.Domain
{
    /// <summary>
    /// Serializes the top level of the GW2Spidy item listing
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class GemPriceListGoldToGems
    {
        [JsonProperty("results")]
        public GemPriceList2GoldToGems Gems { get; set; }
    };

    /// <summary>
    /// Serializes the top level of the GW2Spidy item listing
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class GemPriceListGemsToGold
    {
        [JsonProperty("results")]
        public GemPriceList2GemsToGold Coins { get; set; }
    };

     /// <summary>
    /// Serializes the top level of the GW2Spidy item listing
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class GemPriceList2GoldToGems
    {
        [JsonProperty("gems")]
        public GemPrice GemPrice4GoldToGems { get; set; }
    };

    /// <summary>
    /// Serializes the top level of the GW2Spidy item listing
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class GemPriceList2GemsToGold
    {
        [JsonProperty("coins")]
        public GemPrice GemPrice4GemsToGold { get; set; }
    };

    /// <summary>
    /// Serializes a single GW2Spidy item
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class GemPrice
    {
        [JsonProperty("coins_per_gem")]
        public int coins_per_gem { get; set; }

        [JsonProperty("quantity")]
        public int quantity { get; set; }
    }
}
