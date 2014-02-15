using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GW2Miner.Domain
{
    public enum GW2DBTypeEnum
    {
        Trophy = 1,
        Weapon = 2,
        Armor = 3,
        Consumable = 4,
        Gizmo = 5,
        Trinket = 6,
        Crafting_Material = 7,
        Container = 8,
        Upgrade_Component = 9,
        Minipet = 10,
        Bag = 11,
        Back = 12,
        Trait_Guide = 13,
        Gathering = 14,
        Tool = 15,
        Mini_Deck = 16,
    };

    public enum GW2DBItemRarity
    {
        Junk = 1,
        Basic = 2,
        Fine = 3,
        Masterwork = 4,
        Rare = 5,
        Exotic = 6,
        Legendary = 7,
        Ascended = 8
    };

    public enum GW2DBWeaponType
    {
        Hammer = 1,
        Sword = 2,
        Dagger = 3,
        Harpoon = 4,
        Staff = 5,
        Scepter = 6,
        Greatsword = 7,
        Long_Bow = 8,
        Shield = 9,
        Pistol = 10,
        Axe = 11,
        Speargun = 12,
        Large_Bundle = 13,
        Rifle = 14,
        Warhorn = 15,
        Mace = 16,
        Focus = 17,
        Polearm = 18,
        Short_Bow = 19,
        Torch = 20,
        Trident = 21,
        Small_Bundle = 22,
        Toy = 23,
        NoWeapon = 24,
        Fiery_GreatSword = 25,
        Magnetic_Shield = 26,
        Bow_Of_Frost = 27,
        Lava_Axe = 28,
        Lightning_Hammer = 29,
        Elixir_Gun = 30,
        Flamethrower = 31,
        Tool_Kit = 32,
        Bomb_Kit = 33,
        Grenade_Kit = 34,
        Med_Kit = 35,
        Mine_Kit = 36,
    };

    public enum GW2DBArmorType
    {
        Gloves = 1,
        Boots = 2,
        Coat = 3,
        Helm = 4,
        Leggings = 5,
        Shoulders = 6,
        HelmAquatic = 7,
    };

    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GW2DBArmorWeightType
    {
        All = -1,
        Light = 1,
        Heavy = 2,
        Medium = 3,
        Clothing = 4,
    };

    public enum GW2DBGatheringType
    {
        Logging = 1,
        Foraging = 2,
        Mining = 3,
    };

    public enum GW2DBTrinketType
    {
        Accessory = 1,
        Amulet = 2,
        Ring = 3,
    };

    public enum GW2DBConsumableType
    {
        Generic = 1,
        Food = 2,
        Unlock = 3,
        Transmutation = 4,
        ContractNpc = 5,
        Megaphone = 6,
        Utility = 7,
        Immediate = 8,
        Booze = 9,
        PotionEndurance = 10,
        PotionHealth = 11,
        Unk = 12
    };

    public enum GW2DBUpgradeType
    {
        Armor = 1,
        Weapon = 2,
    }

    public enum GW2DBItemStats
    {
        Power = 1,
        Healing = 2,
        Precision = 3,
        Toughness = 4,
        Critical_Damage = 5,
        Condition_Damage = 6,
        Vitality = 7,
        Attack = 8,
        CritChance = 9,
        Armor = 10,
        Health = 11,
        Defense = 12
    };

    /// <summary>
    /// Serializes a single GW2Spidy item
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2dbItem
    {
        public gw2dbItem()
        {
            Recipes = new List<gw2dbRecipe>();
        }

        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("DataID")]
        public int data_Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Icon")]
        public string ImageUri { get; set; }

        [JsonProperty("Rarity")]
        public GW2DBItemRarity GW2DBRarityId { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("RequiredLevel")]
        public int MinLevel { get; set; }

        [JsonProperty("Level")]
        public int Level { get; set; }

        [JsonProperty("Defense")]
        public int Defense { get; set; }

        [JsonProperty("MinPower")]
        public int MinPower { get; set; }

        [JsonProperty("MaxPower")]
        public int MaxPower { get; set; }

        // always zero?
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Type")]
        public GW2DBTypeEnum GW2DBTypeId { get; set; }

        [JsonProperty("ExternalID")]
        public int GW2DBExternalId { get; set; }

        [JsonProperty("ArmorType")]
        public GW2DBArmorType ArmorType { get; set; }

        [JsonProperty("ArmorWeightType")]
        public GW2DBArmorWeightType ArmorWeightType { get; set; }

        [JsonProperty("WeaponType")]
        public GW2DBWeaponType WeaponType { get; set; }

        [JsonProperty("TrinketType")]
        public GW2DBTrinketType TrinketType { get; set; }

        [JsonProperty("UpgradeType")]
        public GW2DBUpgradeType UpgradeType { get; set; }

        [JsonProperty("GatheringType")]
        public GW2DBGatheringType GatheringType { get; set; }

        [JsonProperty("ConsumableType")]
        public GW2DBConsumableType ConsumableType { get; set; }

        [JsonProperty("Stats")]
        public List<gw2dbStat> Stats { get; set; }

        [JsonProperty("SoldBy")]
        public List<gw2dbSoldBy> SoldBy { get; set; }

        public List<gw2dbRecipe> Recipes { get; set; }

        public gw2apiItem ToGw2ApiItem
        {
            get
            {
                gw2apiItem item = new gw2apiItem();
                item.Id = data_Id;
                item.MinLevel = MinLevel;
                item.Name = Name;
                item.RarityId = RarityId;
                item.TypeId = TypeId;
                item.Description = Description;

                foreach (gw2dbRecipe recipe in Recipes)
                {
                    item.Recipes.Add(recipe.ToGw2ApiRecipe);
                }

                // subtypes TBD

                return item;
            }
        }

        public RarityEnum RarityId
        {
            get
            {
                switch (this.GW2DBRarityId)
                {
                    case GW2DBItemRarity.Ascended: return RarityEnum.Ascended;
                    case GW2DBItemRarity.Basic: return RarityEnum.Basic;
                    case GW2DBItemRarity.Exotic: return RarityEnum.Exotic;
                    case GW2DBItemRarity.Fine: return RarityEnum.Fine;
                    case GW2DBItemRarity.Junk: return RarityEnum.Junk;
                    case GW2DBItemRarity.Legendary: return RarityEnum.Legendary;
                    case GW2DBItemRarity.Masterwork: return RarityEnum.Masterwork;
                    case GW2DBItemRarity.Rare: return RarityEnum.Rare;
                    default:
                        return RarityEnum.All;
                }
            }
        }

        public TypeEnum TypeId
        {
            get
            {
                switch (this.GW2DBTypeId)
                {
                    case GW2DBTypeEnum.Armor: return TypeEnum.Armor;
                    case GW2DBTypeEnum.Back: return TypeEnum.Back;
                    case GW2DBTypeEnum.Bag: return TypeEnum.Bag;
                    case GW2DBTypeEnum.Consumable: return TypeEnum.Consumable;
                    case GW2DBTypeEnum.Container: return TypeEnum.Container;
                    case GW2DBTypeEnum.Crafting_Material: return TypeEnum.Crafting_Material;
                    case GW2DBTypeEnum.Gathering: return TypeEnum.Gathering;
                    case GW2DBTypeEnum.Gizmo: return TypeEnum.Gizmo;
                    case GW2DBTypeEnum.Minipet: return TypeEnum.MiniPet;
                    case GW2DBTypeEnum.Tool: return TypeEnum.Tool;
                    case GW2DBTypeEnum.Trinket: return TypeEnum.Trinket;
                    case GW2DBTypeEnum.Trophy: return TypeEnum.Trophy;
                    case GW2DBTypeEnum.Upgrade_Component: return TypeEnum.Upgrade_Component;
                    case GW2DBTypeEnum.Weapon: return TypeEnum.Weapon;
                    default:
                        return TypeEnum.All;
                }
            }
        }

        public int SubTypeId
        {
            get
            {
                switch (this.GW2DBTypeId)
                {
                    case GW2DBTypeEnum.Armor: return this.ArmorSubTypeId;
                    case GW2DBTypeEnum.Consumable: return this.ConsumableSubTypeId;
                    case GW2DBTypeEnum.Gathering: return this.GatheringSubTypeId;
                    case GW2DBTypeEnum.Trinket: return this.TrinketSubTypeId;
                    case GW2DBTypeEnum.Upgrade_Component: return this.Upgrade_ComponentSubTypeId;
                    case GW2DBTypeEnum.Weapon: return this.WeaponSubTypeId;

                    //case GW2DBTypeEnum.Back: return TypeEnum.Back_Item;
                    //case GW2DBTypeEnum.Bag: return TypeEnum.Bag;
                    //case GW2DBTypeEnum.Container: return TypeEnum.Container;
                    //case GW2DBTypeEnum.Crafting_Material: return TypeEnum.Crafting_Material;
                    //case GW2DBTypeEnum.Gizmo: return TypeEnum.Gizmo;
                    //case GW2DBTypeEnum.Minipet: return TypeEnum.Mini;
                    //case GW2DBTypeEnum.Tool: return TypeEnum.Tool;
                    //case GW2DBTypeEnum.Trophy: return TypeEnum.Trophy;

                    default: return -1;
                }
            }
        }

        private int ArmorSubTypeId
        {
            get
            {
                switch (this.ArmorType)
                {
                    case GW2DBArmorType.Gloves: return (int)ArmorSubTypeEnum.Gloves;
                    case GW2DBArmorType.Boots: return (int)ArmorSubTypeEnum.Boots;
                    case GW2DBArmorType.Coat: return (int)ArmorSubTypeEnum.Coat;
                    case GW2DBArmorType.Helm: return (int)ArmorSubTypeEnum.Helm;
                    case GW2DBArmorType.Leggings: return (int)ArmorSubTypeEnum.Leggings;
                    case GW2DBArmorType.Shoulders: return (int)ArmorSubTypeEnum.Shoulders;
                    case GW2DBArmorType.HelmAquatic: return (int)ArmorSubTypeEnum.Aquatic_Helm;
                    default:
                        return (int)ArmorSubTypeEnum.All;
                }
            }
        }

        private int ConsumableSubTypeId
        {
            get
            {
                switch (this.ConsumableType)
                {
                    case GW2DBConsumableType.Generic: return (int)ConsumableSubTypeEnum.Generic;
                    case GW2DBConsumableType.Food: return (int)ConsumableSubTypeEnum.Food;
                    case GW2DBConsumableType.Unlock: return (int)ConsumableSubTypeEnum.Unlock;
                    case GW2DBConsumableType.Transmutation: return (int)ConsumableSubTypeEnum.Transmutation;
                    case GW2DBConsumableType.Booze: return (int)ConsumableSubTypeEnum.Alcohol;
                    case GW2DBConsumableType.Utility: return (int)ConsumableSubTypeEnum.Utility;

                    //case GW2DBConsumableType.ContractNpc: return (int)ConsumableSubTypeEnum.Food;
                    //case GW2DBConsumableType.Megaphone: return (int)ConsumableSubTypeEnum.Food;
                    //case GW2DBConsumableType.Immediate: return (int)ConsumableSubTypeEnum.Food;
                    //case GW2DBConsumableType.PotionEndurance: return (int)ConsumableSubTypeEnum.Food;
                    //case GW2DBConsumableType.PotionHealth: return (int)ConsumableSubTypeEnum.Food;
                    default:
                        return (int)ConsumableSubTypeEnum.All;
                }
            }
        }

        private int GatheringSubTypeId
        {
            get
            {
                switch (this.GatheringType)
                {
                    case GW2DBGatheringType.Foraging: return (int)GatheringSubTypeEnum.Foraging;
                    case GW2DBGatheringType.Logging: return (int)GatheringSubTypeEnum.Logging;
                    case GW2DBGatheringType.Mining: return (int)GatheringSubTypeEnum.Mining;
                    default:
                        return (int)GatheringSubTypeEnum.All;
                }
            }
        }

        private int TrinketSubTypeId
        {
            get
            {
                switch (this.TrinketType)
                {
                    case GW2DBTrinketType.Accessory: return (int)TrinketSubTypeEnum.Accessory;
                    case GW2DBTrinketType.Amulet: return (int)TrinketSubTypeEnum.Amulet;
                    case GW2DBTrinketType.Ring: return (int)TrinketSubTypeEnum.Ring;
                    default:
                        return (int)TrinketSubTypeEnum.All;
                }
            }
        }

        private int Upgrade_ComponentSubTypeId
        {
            get
            {
                switch (this.UpgradeType)
                {
                    case GW2DBUpgradeType.Armor: return (int)UpgradeComponentSubTypeEnum.Rune;
                    case GW2DBUpgradeType.Weapon: return (int)UpgradeComponentSubTypeEnum.Sigil;
                    default:
                        return (int)UpgradeComponentSubTypeEnum.All;
                }
            }
        }

        private int WeaponSubTypeId
        {
            get
            {
                switch (this.WeaponType)
                {
                    case GW2DBWeaponType.Axe: return (int)WeaponSubTypeEnum.Axe;
                    case GW2DBWeaponType.Dagger: return (int)WeaponSubTypeEnum.Dagger;
                    case GW2DBWeaponType.Focus: return (int)WeaponSubTypeEnum.Focus;
                    case GW2DBWeaponType.Greatsword: return (int)WeaponSubTypeEnum.Greatsword;
                    case GW2DBWeaponType.Hammer: return (int)WeaponSubTypeEnum.Hammer;
                    case GW2DBWeaponType.Harpoon: return (int)WeaponSubTypeEnum.Spear;
                    case GW2DBWeaponType.Long_Bow: return (int)WeaponSubTypeEnum.Long_Bow;
                    case GW2DBWeaponType.Mace: return (int)WeaponSubTypeEnum.Mace;
                    case GW2DBWeaponType.Pistol: return (int)WeaponSubTypeEnum.Pistol;
                    case GW2DBWeaponType.Rifle: return (int)WeaponSubTypeEnum.Rifle;
                    case GW2DBWeaponType.Scepter: return (int)WeaponSubTypeEnum.Scepter;
                    case GW2DBWeaponType.Shield: return (int)WeaponSubTypeEnum.Shield;
                    case GW2DBWeaponType.Short_Bow: return (int)WeaponSubTypeEnum.Short_Bow;
                    case GW2DBWeaponType.Speargun: return (int)WeaponSubTypeEnum.Harpoon_Gun;
                    case GW2DBWeaponType.Staff: return (int)WeaponSubTypeEnum.Staff;
                    case GW2DBWeaponType.Sword: return (int)WeaponSubTypeEnum.Sword;
                    case GW2DBWeaponType.Torch: return (int)WeaponSubTypeEnum.Torch;
                    case GW2DBWeaponType.Trident: return (int)WeaponSubTypeEnum.Trident;
                    case GW2DBWeaponType.Warhorn: return (int)WeaponSubTypeEnum.Warhorn;
                    default:
                        return (int)WeaponSubTypeEnum.All;
                }
            }
        }
    };

    [JsonObject(MemberSerialization.OptIn)]
    public class gw2dbStat
    {
        [JsonProperty("Type")]
        public GW2DBItemStats Type;

        [JsonProperty("Value")]
        public float Value;
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class gw2dbSoldBy
    {
        [JsonProperty("NPCExternalID")]
        public int NPCExternalID;

        [JsonProperty("KarmaCost")]
        public int KarmaCost;

        [JsonProperty("GoldCost")]
        public float GoldCost;

        [JsonProperty("SkillPointCost")]
        public float SkillPointCost;
    }
}
