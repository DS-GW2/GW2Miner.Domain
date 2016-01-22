using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2Miner.Domain
{
    /// <summary>
    /// Serializes a single GW2Spidy recipe
    /// </summary>
    /// <remarks>
    /// See: https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#wiki-full-item-list
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class gw2spidyRecipe
    {
        [JsonProperty("data_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("result_count")]
        public int Quantity { get; set; }

        [JsonProperty("result_item_data_id")]
        public int? CreatedDataId { get; set; }

        [JsonProperty("discipline_id")]
        public GW2DBDisciplines DisciplineId { get; set; }

        [JsonProperty("result_item_max_offer_unit_price")]
        public int CreatedItemMaxBuyUnitPrice { get; set; }

        [JsonProperty("result_item_min_sale_unit_price")]
        public int CreatedItemMinSaleUnitPrice { get; set; }

        [JsonProperty("crafting_cost")]
        public int MinCraftingCost { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }
    }
}
