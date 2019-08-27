using System;
using SiegeApi.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiegeApi.Models
{
    public class Rank
    {
        #region Properties

        [JsonProperty("max_mmr")]
        public double MaxMmr { get; internal set; }

        [JsonProperty("skill_mean")]
        public double SkillMean { get; internal set; }

        [JsonProperty("deaths")]
        public int Deaths { get; internal set; }

        [JsonProperty("profile_id")]
        public string ProfileId { get; internal set; }

        [JsonProperty("next_rank_mmr")]
        public double NextRankMmr { get; internal set; }

        [JsonProperty("rank")]
        public int RankId { get; internal set; }

        [JsonProperty("max_rank")]
        public int MaxRank { get; internal set; }

        [JsonProperty("board_id")]
        public string BoardId { get; internal set; }

        [JsonProperty("skill_stdev")]
        public double SkillStdev { get; internal set; }

        [JsonProperty("kills")]
        public int Kills { get; internal set; }

        [JsonProperty("last_match_skill_stdev_change")]
        public double LastMatchSkillStdevChange { get; internal set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; internal set; }

        [JsonProperty("last_match_mmr_change")]
        public double LastMatchMmrChange { get; internal set; }

        [JsonProperty("abandons")]
        public int Abandons { get; internal set; }

        [JsonProperty("season")]
        public int Season { get; internal set; }

        [JsonProperty("last_match_skill_mean_change")]
        public double LastMatchSkillMeanChange { get; internal set; }

        [JsonProperty("mmr")]
        public double Mmr { get; internal set; }

        [JsonProperty("previous_rank_mmr")]
        public double PreviousRankMmr { get; internal set; }

        [JsonProperty("last_match_result")]
        public int LastMatchResult { get; internal set; }

        [JsonProperty("wins")]
        public int Wins { get; internal set; }

        [JsonProperty("region")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Region Region { get; internal set; }

        [JsonProperty("losses")]
        public int Losses { get; internal set; }

        #endregion
    }
}
