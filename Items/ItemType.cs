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
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeEnum
    {
        All = -1,
        Armor = 0,
        Back = 1,
        Bag = 2,
        Consumable,
        Container,
        [EnumMember(Value = "CraftingMaterial")]
        Crafting_Material,
        Gathering,
        Gizmo,
        MiniPet = 11,
        Tool = 13,
        Trinket = 15,
        Trophy,
        [EnumMember(Value = "UpgradeComponent")]
        Upgrade_Component,
        Weapon
    };
}
