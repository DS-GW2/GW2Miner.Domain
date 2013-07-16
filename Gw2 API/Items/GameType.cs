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
    public enum GW2APIGameTypeEnum
    {
        None = 0,
        [EnumMember]
        Activity = 0x01,
        [EnumMember]
        Dungeon = 0x02,
        [EnumMember]
        Pve = 0x04,
        [EnumMember]
        Pvp = 0x010,
        [EnumMember]
        PvpLobby = 0x020,
        [EnumMember]
        Wvw = 0x040
    }
}
