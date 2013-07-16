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
    // for TypeEnum.Gizmo
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GizmoSubTypeEnum
    {
        All = -1,
        Default = 0,
        Salvage = 2,
        [EnumMember(Value = "RentableContractNpc")]
        Rentable_Contract_Npc,
        [EnumMember(Value = "UnlimitedConsumable")]
        Unlimited_Consumable
    };
}
