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
    // for TypeEnum.UpgradeComponent
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UpgradeComponentSubTypeEnum
    {
        All = -1,
        Default = 0,
        Gem = 1,
        Rune = 2,
        Sigil = 3
    };
}
