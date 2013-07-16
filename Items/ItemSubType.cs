using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2Miner.Domain
{
    /// <summary>
    /// An item subtype for a GW2Spidy item.
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-type-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class ItemSubType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
