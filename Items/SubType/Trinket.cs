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
    // for TypeEnum.Trinket
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrinketSubTypeEnum
    {
        All = -1,
        Accessory = 0,
        Amulet,
        Ring
    };
}
