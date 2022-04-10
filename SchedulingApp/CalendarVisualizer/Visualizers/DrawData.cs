using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp.CalendarVisualizer.Visualizers
{
    internal static class DrawData
    {
        #region Private Fields

        /// <summary>
        /// Представляет контанту числа дней в неделе
        /// </summary>
        private const int DAYS_IN_WEEK = 7;

        /// <summary>
        /// Представляет контанту кол-ва часов на дню
        /// </summary>
        private const int HOURS_IN_DAY = 24;

        /// <summary>
        /// Представляет контанту дня конца недели
        /// </summary>
        private const DayOfWeek END_OF_WEEK = DayOfWeek.Sunday;

        /// <summary>
        /// Представляет контанту числа максимального кол-ва дней в неделе
        /// </summary>
        private const int WEEKS_IN_MONTH = 6;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Представляет число дней в неделе
        /// </summary>
        public static int DaysInWeek => DAYS_IN_WEEK;

        /// <summary>
        /// Представляет или задает дату конца месяца
        /// </summary>
        public static DateTime EndMonth { get; set; }

        /// <summary>
        /// Представляет день конца недели
        /// </summary>
        public static DayOfWeek EndOfWeek => END_OF_WEEK;

        /// <summary>
        /// Представляет или задает дату начала месяца
        /// </summary>
        public static DateTime StartMonth { get; set;}
        /// <summary>
        /// Представляет число максимального кол-ва дней в неделе
        /// </summary>
        public static int WeeksInMonth => WEEKS_IN_MONTH;

        /// <summary>
        /// Представляет кол-ва часов в дне
        /// </summary>
        public static double HoursInDay => HOURS_IN_DAY;

        #endregion Public Properties
    }
}
