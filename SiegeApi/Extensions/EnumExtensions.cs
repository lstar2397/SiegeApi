using System.ComponentModel;
using SiegeApi.Enums;

namespace SiegeApi.Extensions
{
    public static class EnumExtensions
    {
        public static string ToInternalString(this Region region)
        {
            switch (region)
            {
                case Region.ASIA:
                    return "apac";
                case Region.EU:
                    return "emea";
                case Region.NA:
                    return "ncsa";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string ToInternalString(this Platform platform)
        {
            switch (platform)
            {
                case Platform.UPLAY:
                    return "uplay";
                case Platform.XBOX:
                    return "xbl";
                case Platform.PLAYSTATION:
                    return "psn";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string ToInternalUrlString(this Platform platform)
        {
            switch (platform)
            {
                case Platform.UPLAY:
                    return "OSBOR_PC_LNCH_A";
                case Platform.XBOX:
                    return "OSBOR_XBOXONE_LNCH_A";
                case Platform.PLAYSTATION:
                    return "OSBOR_PS4_LNCH_A";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}