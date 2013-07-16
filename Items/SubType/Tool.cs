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
    // for TypeEnum.Tool
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ToolSubTypeEnum
    {
        All = -1,
        Crafting = 0,
        Salvage = 2
    };
}
