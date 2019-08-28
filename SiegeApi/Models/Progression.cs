using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiegeApi.Models
{
    public class Progression
    {
        #region Properties

        [JsonProperty("xp")]
        public string Xp { get; internal set; }

        [JsonProperty("profile_id")]
        public string ProfileId { get; internal set; }

        [JsonProperty("lootbox_probability")]
        public string LootboxProbability { get; internal set; }

        [JsonProperty("level")]
        public string Level { get; internal set; }

        #endregion
    }
}
