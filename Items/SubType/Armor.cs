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
    // for TypeEnum.Armor
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ArmorSubTypeEnum
    {
        All = -1,
        Coat = 0,
        Leggings,
        Gloves,
        Helm,
        [EnumMember(Value = "HelmAquatic")]
        Aquatic_Helm,
        Boots,
        Shoulders
    };
}
