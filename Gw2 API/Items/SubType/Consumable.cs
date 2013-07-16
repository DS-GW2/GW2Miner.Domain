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
    public enum GW2APIUnlockTypeEnum
    {
        [EnumMember(Value = "CraftingRecipe")]
        Crafting_Recipe,
        Dye,
        [EnumMember(Value = "BagSlot")]
        Bag_Slot,
        [EnumMember(Value = "BankTab")]
        Bank_Tab
    }

    /// <summary>
    /// Serializes a single GW2 API consumable item
    /// </summary>
    /// <remarks>
    /// See: https://forum-en.guildwars2.com/forum/community/api/API-Documentation/first#post2028044
    /// and http://wiki.guildwars2.com/wiki/API/item_details
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2apiConsumableItem
    {
        [JsonProperty("type")]
        public ConsumableSubTypeEnum SubTypeId { get; set; }

        [JsonProperty("unlock_type")]
        public GW2APIUnlockTypeEnum UnlockType { get; set; }

        [JsonProperty("recipe_id")]
        public int RecipeId;

        [JsonProperty("duration_ms")]
        public int DurationInMS { get; set; }

        [JsonProperty("description")]
        public string Description;
    }
}
