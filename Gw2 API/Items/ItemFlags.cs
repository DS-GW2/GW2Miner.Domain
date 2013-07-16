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
    public enum GW2APIFlagsEnum
    {
        None = 0,
        [EnumMember(Value = "AccountBound")]
        Account_Bound = 0x01,
        [EnumMember(Value = "HideSuffix")]
        Hide_Suffix = 0x02,
        [EnumMember(Value = "NoMysticForge")]
        No_Mystic_Forge = 0x04,
        [EnumMember(Value = "NoSalvage")]
        No_Salvage = 0x08,
        [EnumMember(Value = "NoSell")]
        No_Sell = 0x010,
        [EnumMember(Value = "NotUpgradeable")]
        Not_Upgradeable = 0x020,
        [EnumMember(Value = "NoUnderwater")]
        No_Underwater = 0x040,
        [EnumMember(Value = "SoulBindOnAcquire")]
        SoulBound_On_Acquire = 0x080,
        [EnumMember(Value = "SoulBindOnUse")]
        SoulBound_On_Use = 0x0100,
        [EnumMember]
        Unique = 0x0200
    }
}
