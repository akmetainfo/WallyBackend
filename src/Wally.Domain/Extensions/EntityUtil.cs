using System;

namespace Usol.Wally.Domain.Extensions
{
    public static class EntityUtil
    {
        public static string Set(string value, int maxLength, string propertyTitle)
        {
            if (value != null && value.Length > maxLength)
                throw new ArgumentOutOfRangeException(nameof(value), $"Length for {propertyTitle} can't exceed {maxLength}.");

            return value;
        }
    }
}