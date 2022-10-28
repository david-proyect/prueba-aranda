using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Common.Constans;

namespace Common.Helpers
{
    public static class DateTimeColombiaHelper
    {
        /// <summary>
        /// Este metodo devuelve la fecha y hora colombiana
        /// </summary>
        /// <returns>fecha y hora colombia</returns>
        public static DateTime GetDateTimeColombia()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                TimeZoneInfo objTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeConstants.TimeZonePacificStandardTime);

                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, objTimeZoneInfo);
            }
            else
            {
                TimeZoneInfo objTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeConstants.TimeZoneAmericaColombia);

                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, objTimeZoneInfo);
            }
        }
    }
}
