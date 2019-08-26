using System.Runtime.Serialization;

namespace SiegeApi.Enums
{
    public enum Platform
    {
        [EnumMember(Value = "uplay")]
        UPLAY,
        [EnumMember(Value = "xbl")]
        XBOX,
        [EnumMember(Value = "psn")]
        PLAYSTATION
    }
}
