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
        #region Private Fields

        /// <summary>
        /// Представляет сервис, отрисовки заднего фона
        /// </summary>
        private readonly BackgroundDrawer _backgroundDrawer;

        /// <summary>
        /// Представляет сервис, визуализации элементов
        /// </summary>
        private readonly ObjectsVisualizers _objectsVisualizers;

        /// <summary>
        /// Представляет объект для данных о датах
        /// </summary>
        private readonly DrawData _drawData;

        #endregion Private Fields

        #region Public Fields

        /// <summary>
        /// Представляет свойство зависимоти, даты месяца в таймлайне
        /// </summary>
        public static readonly DependencyProperty DateMonthProperty
                            = DependencyProperty.Register(nameof(DateMonth),
                                          typeof(DateTime),
                                          typeof(VisualizerControl),
                                          new PropertyMetadata(DateTime.Now, DateMonthPropertyChanged));

        /// <summary>
        /// Обработка события изменения свойства даты месяца
        /// </summary>
        /// <param name="d">Объект зависиомти</param>
        /// <param name="e">Параметр</param>
        private static void DateMonthPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            VisualizerControl control = d as VisualizerControl;
            control._drawData.SetDate(control.DateMonth);
            control._backgroundDrawer.ForceRedraw();
        }

        #endregion Public Fields

        #region Public Properties

        /// <summary>
        /// Представляет или заадет дату месяца в таймлайне
        /// </summary>
        public DateTime DateMonth
        {
            get { return (DateTime)GetValue(DateMonthProperty); }
            set { SetValue(DateMonthProperty, value); }
        }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="VisualizerControl"/>
        /// </summary>
        public VisualizerControl()
        {
            this.InitializeComponent();

            _drawData = new(DateMonth);
            _backgroundDrawer = new BackgroundDrawer(CanvasBackground, _drawData);
            _objectsVisualizers = new ObjectsVisualizers(CanvasManipulation, _drawData);
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Обработка события загрузки контрола
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            CalendarPageViewModel.Instance.LoadMonth();
        }

        #endregion Private Methods

    }
}
