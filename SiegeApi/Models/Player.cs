using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SiegeApi.Enums;
using SiegeApi.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiegeApi.Models
{
    public class Player
    {
        #region Properties

        [JsonProperty("profileId")]
        public string ProfileId { get; internal set; }

        [JsonProperty("userId")]
        public string UserId { get; internal set; }

        [JsonProperty("platformType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Platform PlatformType { get; internal set; }

        [JsonProperty("idOnPlatform")]
        public string IdOnPlatform { get; internal set; }

        [JsonProperty("nameOnPlatform")]
        public string NameOnPlatform { get; internal set; }

        #endregion

        private Progression _progression;
        private Dictionary<string, Rank> _ranks;

        private async Task FetchProgression()
        {
            Uri progressionUri = new Uri(Constants.ProgressionUrls[PlatformType])
                .AddParameter("profile_ids", ProfileId);

            var data = await Api.Instance.FetchData(progressionUri);
            var progression = data["player_profiles"].ToObject<IEnumerable<Progression>>().FirstOrDefault();

            _progression = progression;
        }

        private async Task FetchRank(Region region, int season = -1)
        {
            Uri rankUri = new Uri(Constants.RankUrls[PlatformType])
                .AddParameter("board_id", "pvp_ranked")
                .AddParameter("region_id", region.ToInternalString())
                .AddParameter("season_id", season.ToString())
                .AddParameter("profile_ids", ProfileId);

            var data = await Api.Instance.FetchData(rankUri);
            var rank = JsonConvert.DeserializeObject<Rank>(data["players"][ProfileId].ToString());

            if (_ranks == null)
                _ranks = new Dictionary<string, Rank>();

            _ranks.Add($"{region.ToInternalString()}:{season}", rank);
        }

        public async Task<Progression> GetProgression()
        {
            if (_progression == null)
                await FetchProgression();

            return _progression;
        }

        public async Task<Rank> GetRank(Region region, int season = -1)
        {
            string key = $"{region.ToInternalString()}:{season}";

            if (_ranks == null || !_ranks.ContainsKey(key))
                await FetchRank(region, season);

            return _ranks[key];
        }
    }
}
