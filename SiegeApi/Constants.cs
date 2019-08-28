using System.Collections.Generic;
using SiegeApi.Enums;

namespace SiegeApi
{
    internal static class Constants
    {
        public static readonly string AuthorizationUrl = "https://connect.ubi.com/ubiservices/v2/profiles/sessions";

        public static readonly string ProfileUrl = "https://public-ubiservices.ubi.com/v2/profiles";

        public static readonly Dictionary<Platform, string> RankUrls = new Dictionary<Platform, string>()
        {
            { Platform.Uplay, "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6karma/players" },
            { Platform.Xbox, "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_XBOXONE_LNCH_A/r6karma/players" },
            { Platform.Playstation, "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_PS4_LNCH_A/r6karma/players" }
        };

        public static readonly Dictionary<Platform, string> ProgressionUrls = new Dictionary<Platform, string>()
        {
            { Platform.Uplay, "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6playerprofile/playerprofile/progressions" },
            { Platform.Xbox, "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_XBOXONE_LNCH_A/r6playerprofile/playerprofile/progressions" },
            { Platform.Playstation, "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_PS4_LNCH_A/r6playerprofile/playerprofile/progressions" }
        };
    }
}
