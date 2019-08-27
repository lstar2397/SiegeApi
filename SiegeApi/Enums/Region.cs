using System.Runtime.Serialization;

namespace SiegeApi.Enums
{
    public enum Region
    {
        [EnumMember(Value = "apac")]
        Asia,
        [EnumMember(Value = "emea")]
        Europe,
        [EnumMember(Value = "ncsa")]
        NorthAmerica
    }
}
