using System.Runtime.Serialization;

namespace SiegeApi.Enums
{
    public enum Region
    {
        [EnumMember(Value = "apac")]
        ASIA,
        [EnumMember(Value = "emea")]
        EU,
        [EnumMember(Value = "ncsa")]
        NA
    }
}
