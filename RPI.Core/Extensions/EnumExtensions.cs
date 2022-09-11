using System;

namespace RPI.Core.Extensions;

public static class EnumExtensions
{
    public static T ConvertTo<T>(this Enum value) 
        where T : struct
    {
        var t = Enum.Parse<T>(value.ToString());
        return t;
    }
}