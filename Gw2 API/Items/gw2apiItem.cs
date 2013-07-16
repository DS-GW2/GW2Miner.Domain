using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GW2Miner.Domain
{
    /// <summary>
    /// Serializes a single GW2 API item
    /// </summary>
    /// <remarks>
    /// See: https://forum-en.guildwars2.com/forum/community/api/API-Documentation/first#post2028044
    /// and http://wiki.guildwars2.com/wiki/API/item_details
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2apiItem
    {
        [JsonProperty("item_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public TypeEnum TypeId { get; set; }

        [JsonProperty("level")]
        public int MinLevel { get; set; }

        [JsonProperty("rarity")]
        public RarityEnum RarityId { get; set; }

        [JsonProperty("vendor_value")]
        public int VendorPrice { get; set; }

        [JsonProperty("game_types")]
        public GW2APIGameTypeEnum GameType;

        [JsonProperty("flags")]
        public GW2APIFlagsEnum Flags;

        [JsonProperty("restrictions")]
        public GW2APIRestrictionsEnum Restrictions;

        [JsonProperty("armor")]
        public gw2apiArmorItem Armor;

        [JsonProperty("back")]
        public gw2apiBackItem Back;

        [JsonProperty("bag")]
        public gw2apiBagItem Bag;

        [JsonProperty("consumable")]
        public gw2apiConsumableItem Consumable;

        [JsonProperty("container")]
        public gw2apiContainerItem Container;

        [JsonProperty("gathering")]
        public gw2apiGatheringItem Gathering;

        [JsonProperty("gizmo")]
        public gw2apiGizmoItem Gizmo;

        [JsonProperty("tool")]
        public gw2apiToolItem Tool;

        [JsonProperty("trinket")]
        public gw2apiTrinketItem Trinket;

        [JsonProperty("upgrade_component")]
        public gw2apiUpgradeComponentItem UpgradeComponent;

        [JsonProperty("weapon")]
        public gw2apiWeaponItem Weapon;
    }
}
