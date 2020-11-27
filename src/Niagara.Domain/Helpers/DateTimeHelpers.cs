using System;
using System.Globalization;

namespace Niagara.Domain.Helpers
{
    public static class DateTimeHelpers
    {
        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        }

        public static string ToTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}