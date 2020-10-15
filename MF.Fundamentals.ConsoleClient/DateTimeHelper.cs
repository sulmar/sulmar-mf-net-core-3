using System;
using System.Collections.Generic;
using System.Text;

namespace MF.Fundamentals.Extensions
{
    public class DateTimeHelper
    {
        public static bool IsHoliday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }


    // Metoda rozszerzająca (Extension Method)
    // Dodaje nowe metody do wskazanego typu (klasy, interfejsu) poprzez operator this

    // Muszą być spełnione następujące warunki:
    // - Klasa publiczna statyczna (public static class)
    // - Metoda publiczna statyczna (public static)
    // - operator this

    public static class DateTimeExtensions
    {
        public static bool IsHoliday(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime AddWorkingDays(this DateTime date, int days)
        {
            return date.AddDays(days);
        }
    }


    // Normalization

    public static class StringExtensions
    {
        public static string Normalization(this string content)
        {
            return content.Replace(" " , "");
        }
    }

}
