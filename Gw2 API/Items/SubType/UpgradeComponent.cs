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
    [Flags]
    [JsonConverter(typeof(JsonFlagsEnumTypeConverter))]
    public enum GW2APIUpgradeComponentFlagsEnum
    {
        None = 0,
        [EnumMember]
        HeavyArmor = 0x01,
        [EnumMember]
        LightArmor = 0x02,
        [EnumMember]
        MediumArmor = 0x04,
        [EnumMember]
        Sword = 0x08,
        [EnumMember]
        Hammer = 0x010,
        [EnumMember(Value = "LongBow")]
        Long_Bow = 0x020,
        [EnumMember(Value = "ShortBow")]
        Short_Bow = 0x040,
        [EnumMember]
        Axe = 0x080,
        [EnumMember]
        Dagger = 0x0100,
        [EnumMember]
        Greatsword = 0x0200,
        [EnumMember]
        Mace = 0x0400,
        [EnumMember]
        Pistol = 0x0800,
        [EnumMember]
        Rifle = 0x01000,
        [EnumMember]
        Scepter = 0x02000,
        [EnumMember]
        Staff = 0x04000,
        [EnumMember]
        Focus = 0x08000,
        [EnumMember]
        Torch = 0x010000,
        [EnumMember]
        Warhorn = 0x020000,
        [EnumMember]
        Shield = 0x040000,
        [EnumMember(Value = "Harpoon")]
        Spear = 0x080000,
        [EnumMember(Value = "Speargun")]
        Harpoon_Gun = 0x0100000,
        [EnumMember]
        Trident = 0x0200000,
        [EnumMember]
        Trinket = 0x0400000
    }

    /// <summary>
    /// Serializes a single GW2 API upgrade component item
    /// </summary>
    /// <remarks>
    /// See: https://forum-en.guildwars2.com/forum/community/api/API-Documentation/first#post2028044
    /// and http://wiki.guildwars2.com/wiki/API/item_details
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2apiUpgradeComponentItem
    {
        [JsonProperty("type")]
        public UpgradeComponentSubTypeEnum SubTypeId { get; set; }

        [JsonProperty("flags")]
        public GW2APIUpgradeComponentFlagsEnum Flags { get; set; }

        [JsonProperty("infusion_upgrade_flags")]
        public GW2APIInfusionSlotFlagsEnum InfusionUpgradeFlags;

        [JsonProperty("infix_upgrade")]
        public gw2apiInfixUpgrade InfixUpgrade;

        [JsonProperty("bonuses")]
        public List<string> Bonuses;

        [JsonProperty("suffix")]
        public string Suffix;
    }
}
