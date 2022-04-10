using SchedulingApp.Presenter.Pages;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace SchedulingApp.CalendarVisualizer.Visualizers
{
    /// <summary>
    /// Представляет контрол, визиализации расписании месяца
    /// </summary>
    public sealed partial class VisualizerControl : UserControl
    {
        /// <summary>
        /// Представляет сервис, отрисовки заднего фона
        /// </summary>
        private readonly BackgroundDrawer _backgroundDrawer;

        /// <summary>
        /// Представляет сервис, визуализации элементов
        /// </summary>
        private readonly ObjectsVisualizers _objectsVisualizers;

        /// <summary>
        /// Инициализирует экземпляр <see cref="VisualizerControl"/>
        /// </summary>
        public VisualizerControl()
        {
            this.InitializeComponent();

            DrawData.StartMonth = new DateTime(2022, 4, 1);
            DrawData.EndMonth = new DateTime(2022, 4, 30);

            _backgroundDrawer = new BackgroundDrawer(CanvasBackground);
            _objectsVisualizers = new ObjectsVisualizers(CanvasManipulation);
        }

        /// <summary>
        /// Обработка события загрузки контрола
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            CalendarPageViewModel.Instance.LoadMonth();
        }
    }
}
