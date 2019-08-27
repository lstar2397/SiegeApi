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
                case Region.Asia:
                    return "apac";
                case Region.Europe:
                    return "emea";
                case Region.NorthAmerica:
                    return "ncsa";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string ToInternalString(this Platform platform)
        {
            switch (platform)
            {
                case Platform.Uplay:
                    return "uplay";
                case Platform.Xbox:
                    return "xbl";
                case Platform.Playstation:
                    return "psn";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}