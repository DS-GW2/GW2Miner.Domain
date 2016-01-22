using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2Miner.Domain
{
    /// <summary>
    /// Serializes the top level of the GW2Spidy Gem Price
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-current-gem-price
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2spidyGemPriceResult
    {
        [JsonProperty("gem_to_gold")]
        public int GemsToGold { get; set; }

        [JsonProperty("gold_to_gem")]
        public int GoldToGems { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class gw2spidyGemPrice
    {
        [JsonProperty("result")]
        public gw2spidyGemPriceResult GemPrice { get; set; }
    }
}
