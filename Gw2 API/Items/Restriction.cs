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
    public enum GW2APIRestrictionsEnum
    {
        None = 0,
        [EnumMember]
        Asura = 0x01,
        [EnumMember]
        Charr = 0x02,
        [EnumMember]
        Human = 0x04,
        [EnumMember]
        Norn = 0x08,
        [EnumMember]
        Sylvari = 0x010,
        [EnumMember]
        Guardian = 0x020,
        [EnumMember]
        Warrior = 0x040
    }
}
