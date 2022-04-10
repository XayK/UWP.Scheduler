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
        /// Представляет контанту кол-ва часов на дню
        /// </summary>
        private const int HOURS_IN_DAY = 24;


        /// <summary>
        /// Представляет контанту числа максимального кол-ва дней в неделе
        /// </summary>
        private const int WEEKS_IN_MONTH = 6;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Представляет или задает дату конца месяца
        /// </summary>
        public static DateTime EndMonth { get; set; }

        /// <summary>
        /// Представляет кол-ва часов в дне
        /// </summary>
        public static double HoursInDay => HOURS_IN_DAY;

        /// <summary>
        /// Представляет или задает дату начала месяца
        /// </summary>
        public static DateTime StartMonth { get; set;}

        /// <summary>
        /// Представляет число максимального кол-ва дней в неделе
        /// </summary>
        public static int WeeksInMonth => WEEKS_IN_MONTH;

        #endregion Public Properties
    }
}
