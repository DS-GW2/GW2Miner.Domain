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
    // for TypeEnum.Gathering
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GatheringSubTypeEnum
    {
        All = -1,
        Foraging = 0,
        Logging,
        Mining
    };
}
