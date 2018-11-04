using System;
using System.Globalization;

namespace TTracker
{
    public static class Tools
    {
        public static DateTime StringToDate(string dateString, string locale)
        {
            //Velosiped style
            string _dateString = $"{dateString} 01:00:10";
            DateTime date = Convert.ToDateTime(_dateString, new CultureInfo(locale));
            return date;
        }
    }
}
