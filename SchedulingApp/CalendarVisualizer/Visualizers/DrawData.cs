using System;

namespace SchedulingApp.CalendarVisualizer.Visualizers
{
    /// <summary>
    /// Представляет данные, по датам, необходимые для отрисовки таймлайна
    /// </summary>
    internal class DrawData
    {
        #region Private Fields

        /// <summary>
        /// Представляет контанту кол-ва часов на дню
        /// </summary>
        private const int HOURS_IN_DAY = 24;

        /// <summary>
        /// Представляет контанту кол-ва минут в часу
        /// </summary>
        private const int MINUTES_IN_HOUR = 60;

        /// <summary>
        /// Представляет контанту числа максимального кол-ва дней в неделе
        /// </summary>
        private const int WEEKS_IN_MONTH = 6;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Представляет или задает дату конца месяца
        /// </summary>
        public DateTime EndMonth { get; set; }

        /// <summary>
        /// Представляет кол-ва часов в дне
        /// </summary>
        public double HoursInDay => HOURS_IN_DAY;

        /// <summary>
        /// Представляет кол-ва минут в часе
        /// </summary>
        public double MinutsInHour => MINUTES_IN_HOUR;

        /// <summary>
        /// Представляет или задает дату начала месяца
        /// </summary>
        public DateTime StartMonth { get; set; }

        /// <summary>
        /// Представляет число максимального кол-ва дней в неделе
        /// </summary>
        public int WeeksInMonth => WEEKS_IN_MONTH;

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземлпяр <see cref="DrawData"/>
        /// </summary>
        /// <param name="month">Дата, указывающий на месяц</param>
        public DrawData(DateTime month)
        {
            SetDate(month);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Установка нового значения дат
        /// </summary>
        /// <param name="date">Дата для установки</param>
        public void SetDate(DateTime date)
        {
            StartMonth = new DateTime(date.Year, date.Month, 1);

            int endYear = date.Year;
            int endMonth = date.Month + 1;

            if (endMonth > 12)
            {
                endMonth = 1;
                endYear++;
            }

            EndMonth = new DateTime(endYear, endMonth, 1) - TimeSpan.FromDays(1);
        }

        #endregion Public Methods
    }
}
