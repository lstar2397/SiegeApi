using System.Runtime.Serialization;

namespace SiegeApi.Enums
{
    public enum Platform
    {
        [EnumMember(Value = "uplay")]
        Uplay,
        [EnumMember(Value = "xbl")]
        Xbox,
        [EnumMember(Value = "psn")]
        Playstation
    }
}
