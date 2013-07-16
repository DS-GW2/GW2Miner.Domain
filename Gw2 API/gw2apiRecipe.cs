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
    public enum GW2APIRecipeType
    {
        Refinement,
        Component,
        Bulk,
        Bag,
        Dye,
        Potion,
        [EnumMember(Value = "UpgradeComponent")]
        Upgrade_Component,
        Inscription,
        Insignia,
        Consumable,
        Dessert,
        [EnumMember(Value = "IngredientCooking")]
        Cooking_Ingredient,
        Seasoning,
        Feast,
        Snack,
        Soup,
        Meal,
        Coat,
        Leggings,
        Gloves,
        Helm,
        //[EnumMember(Value = "HelmAquatic")]
        //Aquatic_Helm,
        Boots,
        Shoulders,
        Sword,
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
        Rifle,
        Scepter,
        Staff,
        Focus,
        Torch,
        Warhorn,
        Shield,
        [EnumMember(Value = "Harpoon")]
        Spear,
        [EnumMember(Value = "Speargun")]
        Harpoon_Gun,
        Trident,
        Amulet,
        Ring,
        [EnumMember(Value = "Earring")]
        Accessory
    }

    [DataContract][Flags]
    [JsonConverter(typeof(JsonFlagsEnumTypeConverter))]
    public enum GW2APIDisciplines
    {
        None = 0,
        [EnumMember]
        Huntsman = 0x01,
        [EnumMember]
        Artificer = 0x02,
        [EnumMember]
        Weaponsmith = 0x04,
        [EnumMember]
        Armorsmith = 0x08,
        [EnumMember]        
        Leatherworker = 0x010,
        [EnumMember]
        Tailor = 0x020,
        [EnumMember]
        Jeweler = 0x040,
        [EnumMember(Value = "Chef")]
        Cook = 0x080
    }

    [DataContract][Flags]
    [JsonConverter(typeof(JsonFlagsEnumTypeConverter))]
    public enum GW2APIRecipeFlags
    {
        None = 0,
        [EnumMember(Value = "AutoLearned")]
        Auto_Learned = 0x01,
        [EnumMember(Value = "LearnedFromItem")]
        Learned_From_Item = 0x02
    }

    /// <summary>
    /// Serializes a single GW2 API Recipe
    /// </summary>
    /// <remarks>
    /// See: https://forum-en.guildwars2.com/forum/community/api/API-Documentation/first#post2028044
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2apiRecipe
    {
        [JsonProperty("recipe_id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public GW2APIRecipeType Type { get; set; }

        [JsonProperty("disciplines")]
        public GW2APIDisciplines DisciplineIds { get; set; }

        [JsonProperty("flags")]
        public GW2APIRecipeFlags Flags { get; set; }

        [JsonProperty("output_item_id")]
        public int CreatedDataId { get; set; }

        [JsonProperty("output_item_count")]
        public int Quantity { get; set; }

        [JsonProperty("min_rating")]
        public int Rating { get; set; }

        [JsonProperty("time_to_craft_ms")]
        public int CraftingTime { get; set; }

        [JsonProperty("ingredients")]
        public List<gw2apiIngredient> Ingredients { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class gw2apiIngredient
    {
        [JsonProperty("item_id")]
        public int Id { get; set; }

        [JsonProperty("count")]
        public int Quantity { get; set; }
    }
}
