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
    // for TypeEnum.Consumable
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConsumableSubTypeEnum
    {
        All = -1,
        [EnumMember(Value = "Booze")]
        Alcohol = 1,
        Generic,
        Food = 3,
        Tonics = 4,         // Suppose to be Generic?
        Transmutation = 5,
        Unlock,
        Skins = 7,
        Dyes_and_Recipes = 8,  // Suppose to be Unlock?
        Utility = 9,
        [EnumMember(Value = "ContractNpc")]
        Contract_Npc,
        [EnumMember(Value = "AppearanceChange")]
        Appearance_Change,
        Immediate,
        Halloween
    };
}
