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
    // for TypeEnum.Weapon
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WeaponSubTypeEnum
    {
        All = -1,
        Sword = 0,
        Hammer,
        [EnumMember(Value = "LongBow")]
        Long_Bow,
        [EnumMember(Value = "ShortBow")]
        Short_Bow,
        Axe,
        Dagger,
        Greatsword,
        Mace,
        Pistol,
        Rifle = 10,
        Scepter,
        Staff,
        Focus,
        Torch,
        Warhorn,
        Shield,
        [EnumMember(Value = "Harpoon")]
        Spear = 19,
        [EnumMember(Value = "Speargun")]
        Harpoon_Gun,
        Trident,
        Toy,
        [EnumMember(Value = "TwoHandedToy")]
        Two_Handed_Toy,
        [EnumMember(Value = "SmallBundle")]
        Small_Bundle,
        [EnumMember(Value = "LargeBundle")]
        Large_Bundle
    };
}
