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
    // for TypeEnum.Container
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContainerSubTypeEnum
    {
        All = -1,
        Default = 0,
        [EnumMember(Value = "GiftBox")]
        Gift_Box
    };
}
