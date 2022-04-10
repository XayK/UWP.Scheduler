using Windows.UI.Xaml.Controls;

namespace SchedulingApp.CalendarVisualizer.Controls
{
    /// <summary>
    /// Представляет колнтрол задачи, для отображения на календаре
    /// </summary>
    public sealed partial class MissionTimelineControl : UserControl
    {
        /// <summary>
        /// Инициализирует экземляр <see cref="MissionTimelineControl"/>
        /// </summary>
        /// <param name="presenter">Презентер данных</param>
        public MissionTimelineControl(object presenter)
        {
            this.InitializeComponent();
            this.DataContext = presenter;
        }
    }
}
