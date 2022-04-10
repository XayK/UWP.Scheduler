using System;

namespace SchedulingApp.CalendarVisualizer.Helpers
{
    /// <summary>
    /// Предсталяет методы по преобразаванию дней недели
    /// </summary>
    internal static class DayOfWeekHelper
    {
        /// <summary>
        /// Получение номера дня недели в григорианском представлении
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Номер дня недели, где Понедельник - 0, а воскресенье будет 6</returns>
        public static int GrigorianDayOfWeek(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return 6;
                case DayOfWeek.Monday:
                    return (int)date.DayOfWeek - 1;
                case DayOfWeek.Tuesday:
                    return (int)date.DayOfWeek - 1;
                case DayOfWeek.Wednesday:
                    return (int)date.DayOfWeek - 1;
                case DayOfWeek.Thursday:
                    return (int)date.DayOfWeek - 1;
                case DayOfWeek.Friday:
                    return (int)date.DayOfWeek - 1;
                case DayOfWeek.Saturday:
                    return (int)date.DayOfWeek - 1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(date.DayOfWeek));
            }
        }
    }
}
