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
    public class gw2spidyItemList
    {
        [JsonProperty("total")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public List<Item> Items { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class gw2spidyItemResult
    {
        [JsonProperty("result")]
        public gw2spidyItem Item { get; set; }
    }
}
