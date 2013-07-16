using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2Miner.Domain
{
    /// <summary>
    /// Serializes the top level of the item listing
    /// </summary>
    /// <remarks>
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class Args
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }
    }

    /// <summary>
    /// Serializes the top level of the item listing
    /// </summary>
    /// <remarks>
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemList
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("args")]
        public Args args { get; set; }

        [JsonProperty("results")]
        public List<Item> Items { get; set; }
    }

    /// <summary>
    /// Serializes the top level of the item listing
    /// </summary>
    /// <remarks>
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class MyItemList
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("args")]
        public Args args { get; set; }

        [JsonProperty("listings")]
        public List<Item> Items { get; set; }
    }
}
