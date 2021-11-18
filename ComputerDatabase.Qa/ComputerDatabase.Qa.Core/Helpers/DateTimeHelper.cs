using System;
using System.Globalization;

namespace ComputerDatabase.Qa.Core.Helpers
{
    //Helps to get and convert dates
    public class DateTimeHelper
    {
        public static DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        public static string GetCurrentDateTimeInLoggingFormat()
        {
            return GetCurrentDateTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static DateTime FormatDate(string date, string expectedDateFormat)
        {
            return DateTime.ParseExact(date, expectedDateFormat, CultureInfo.InvariantCulture);
        }

        public static DateTime FormatDate(string date)
        {
            DateTime.TryParse(date, out DateTime result);
            return result;
        }
    }
}
