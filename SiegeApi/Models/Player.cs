using SiegeApi.Enums;
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
    }
}
