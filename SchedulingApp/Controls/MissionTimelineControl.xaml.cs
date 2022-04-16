using System;
using Windows.UI.Xaml.Controls;

namespace SchedulingApp.Controls
{
    /// <summary>
    /// Представляет колнтрол задачи, для отображения на календаре
    /// </summary>
    public sealed partial class MissionTimelineControl : UserControl
    {
        #region Public Properties

        /// <summary>
        /// Представляет или задает дату конца визуализации задачи
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Представляет или задает дату начала визуализации задачи
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Представляет или задает позицию  смещения
        /// </summary>
        public int OffsetPosition { get; set; }

        /// <summary>
        /// Представляет или задает кол-во соседей у контрола
        /// </summary>
        public int NeigthboorsCounter { get; set; }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземляр <see cref="MissionTimelineControl"/>
        /// </summary>
        /// <param name="presenter">Презентер данных</param>
        public MissionTimelineControl(object presenter)
        {
            this.InitializeComponent();
            this.DataContext = presenter;
        }

        #endregion Public Constructors
    }
}
