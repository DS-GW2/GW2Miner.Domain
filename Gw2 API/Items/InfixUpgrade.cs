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
    /// <summary>
    /// Serializes a single GW2 API Infix Upgrade
    /// </summary>
    /// <remarks>
    /// See: https://forum-en.guildwars2.com/forum/community/api/API-Documentation/first#post2028044
    /// and http://wiki.guildwars2.com/wiki/API/item_details
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2apiInfixUpgrade
    {
        [JsonProperty("buff")]
        public gw2apiInfixUpgradeBuff Buff;

        [JsonProperty("attributes")]
        public List<gw2apiInfixUpgradeAttribute> Attributes;
    }

    /// <summary>
    /// Serializes a single GW2 API Infix Upgrade Attribute
    /// </summary>
    /// <remarks>
    /// See: https://forum-en.guildwars2.com/forum/community/api/API-Documentation/first#post2028044
    /// and http://wiki.guildwars2.com/wiki/API/item_details
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2apiInfixUpgradeAttribute
    {
        [JsonProperty("attribute")]
        public GW2APIInfixUpgradeAttributeEnum Attribute;

        [JsonProperty("modifier")]
        public int Modifier;
    }

    /// <summary>
    /// Serializes a single GW2 API Infix Upgrade Buff
    /// </summary>
    /// <remarks>
    /// See: https://forum-en.guildwars2.com/forum/community/api/API-Documentation/first#post2028044
    /// and http://wiki.guildwars2.com/wiki/API/item_details
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2apiInfixUpgradeBuff
    {
        [JsonProperty("skill_id")]
        public int SkillId;

        [JsonProperty("description")]
        public string Description;
    }

    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GW2APIInfixUpgradeAttributeEnum
    {
        Power = 1,
        Healing = 2,
        Precision = 3,
        Toughness = 4,
        [EnumMember(Value = "CritDamage")]
        Critical_Damage = 5,
        [EnumMember(Value = "ConditionDamage")]
        Condition_Damage = 6,
        Vitality = 7
    }
}
