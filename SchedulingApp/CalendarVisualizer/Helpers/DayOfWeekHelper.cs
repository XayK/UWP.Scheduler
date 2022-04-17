using System;

namespace SchedulingApp.CalendarVisualizer.Helpers
{
    /// <summary>
    /// Предсталяет методы по преобразаванию дней недели
    /// </summary>
    internal static class DayOfWeekHelper
    {

        #region Private Fields

        /// <summary>
        /// Представляет контанту числа дней в неделе
        /// </summary>
        private const int DAYS_IN_WEEK = 7;

        /// <summary>
        /// Представляет контанту дня конца недели
        /// </summary>
        private const DayOfWeek END_OF_WEEK = DayOfWeek.Sunday;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Представляет число дней в неделе
        /// </summary>
        public static int DaysInWeek => DAYS_IN_WEEK;

        /// <summary>
        /// Представляет день конца недели
        /// </summary>
        public static DayOfWeek EndOfWeek => END_OF_WEEK;

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Вычисляет кол-во прошедших недель в месяце у дата
        /// </summary>
        /// <param name="startVisualize">Дата типа <see cref="DateTime"/></param>
        public static int GetWeekPassedOnMonth(DateTime startVisualize)
        {
            DateTime startMonth = new(startVisualize.Year, startVisualize.Month, 1);
            int weeksPassed = 0;
            DateTime day;
            for (day = startMonth; day < startVisualize.Date; day += TimeSpan.FromDays(1))
            {
                if (day.DayOfWeek == EndOfWeek)
                {
                    weeksPassed++;
                }
            }

            return weeksPassed;
        }

        /// <summary>
        /// Вычисляет кол-во дней, оставшихся до конца неедли
        /// </summary>
        /// <param name="dateTime">Дата, для вычисления</param>
        /// <returns>Возвращает время в <see cref="TimeSpan"/></returns>
        public static TimeSpan LeftToEndOfWeek(DateTime dateTime) => TimeSpan.FromDays
                    (DaysInWeek - GrigorianDayOfWeek(dateTime));

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

        #endregion Public Methods

    }
}
