using SchedulingApp.Abstraction;
using SchedulingApp.Presenter.Pages;
using Windows.UI.Xaml.Controls;


namespace SchedulingApp.Pages
{
    /// <summary>
    /// Представляет страницу, отображающую задачи при помощи календаря
    /// </summary>
    public sealed partial class CalendarPage : Page, IPageView
    {
        #region Private Fields

        /// <summary>
        /// Предоставляет доступ к инстантсу ViewModel
        /// </summary>
        private readonly static object _viewModel = CalendarPageViewModel.Instance;

        #endregion Private Fields

        #region Public Properties

        /// <summary> <inheritdoc/> </summary>
        public object ViewModel => _viewModel;

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Инициализириует экземпляр <see cref="CalendarPage"/>
        /// </summary>
        public CalendarPage()
        {
            this.InitializeComponent();
        }

        #endregion Public Constructors
    }
}
