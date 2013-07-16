using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GW2Miner.Domain
{
    [DataContract]
    [Flags]
    [JsonConverter(typeof(JsonFlagsEnumTypeConverter))]
    public enum GW2APIInfusionSlotFlagsEnum
    {
        None = 0,
        [EnumMember]
        Defense = 0x01,
        [EnumMember]
        Offense = 0x02,
        [EnumMember]
        Utility = 0x04
    }

    /// <summary>
    /// Serializes a single GW2 API infusion slot
    /// </summary>
    /// <remarks>
    /// See: https://forum-en.guildwars2.com/forum/community/api/API-Documentation/first#post2028044
    /// and http://wiki.guildwars2.com/wiki/API/item_details
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2apiInfusionSlot
    {
        [JsonProperty("flags")]
        public GW2APIInfusionSlotFlagsEnum Flags;

        //[JsonProperty("item")]
        //public string Item;
    }
}
