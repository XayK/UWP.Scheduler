using SchedulingApp.Pages;
using SchedulingApp.Presenter.Pages;
using SchedulingApp.Presenter.Pages.Abstraction;
using SchedulingApp.Services.Abstraction;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SchedulingApp.Services
{
    /// <summary>
    /// Представляет функционал навигации по страницам приложения
    /// </summary>
    internal class NavigationService : INavigationService
    {

        #region Private Fields

        /// <summary>
        /// Предоставляет фрейм, отображающий страницу,
        /// а также выполняющий роль навигатора
        /// </summary>
        private readonly Frame _contentFrame;

        /// <summary>
        /// Представляет использумые страницы для навигации
        /// </summary>
        private readonly IDictionary<PagesEnum, Type> _pages;

        /// <summary>
        /// Представляет использумые ViewModel страниц для навигации
        /// </summary>
        private readonly IDictionary<PagesEnum, object> _viewModels;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Предоставляет текущую страницу
        /// </summary>
        public PagesEnum CurrentPage { get; private set; }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="NavigationService"/>
        /// </summary>
        public NavigationService(Frame frame)
        {
            _contentFrame = frame;
            _contentFrame.Navigated += ContentFrame_Navigated;

            _pages = new Dictionary<PagesEnum, Type>()
            {
                { PagesEnum.CalendarPageType , typeof(CalendarPage) },
                { PagesEnum.ListPageType , typeof(ListPage) },
                { PagesEnum.ImportantPageType , typeof(ListPage) },
                { PagesEnum.TodayPageType , typeof(ListPage) }
            };

            _viewModels = new Dictionary<PagesEnum, object>()
            {
                { PagesEnum.CalendarPageType , CalendarPageViewModel.Instance },
                { PagesEnum.ListPageType , ListPageViewModel.Instance },
                { PagesEnum.ImportantPageType , ImportantPageViewModel.Instance },
                { PagesEnum.TodayPageType , TodayPageViewModel.Instance }
            };
        }

        #endregion Public Constructors

        #region Private Destructors

        /// <summary>
        /// Удаляет экземпляр <see cref="NavigationService"/>
        /// </summary>
        ~NavigationService()
        {
            _contentFrame.Navigated -= ContentFrame_Navigated;
        }

        #endregion Private Destructors

        #region Private Methods

        /// <summary>
        /// Обработка события завершения перехода на страницу.
        /// После перехода будет подгружена соотвествуя <see cref="Frame"/>'у ViewModel,
        /// найденная по словарю <see cref="_viewModels"/>
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            _contentFrame.DataContext = _viewModels[CurrentPage];
            IListPageViewModel dataContext;

            switch (CurrentPage)
            {
                case PagesEnum.ListPageType:
                    dataContext = _contentFrame.DataContext as ListPageViewModel;
                    dataContext.ReloadMissions();
                    break;
                case PagesEnum.ImportantPageType:
                    dataContext = _contentFrame.DataContext as ImportantPageViewModel;
                    dataContext.ReloadMissions();
                    break;
                case PagesEnum.TodayPageType:
                    dataContext = _contentFrame.DataContext as TodayPageViewModel;
                    dataContext.ReloadMissions();
                    break;
            }
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// Осуществляет навигацию по стеку "назад"
        /// </summary>
        public void GoBack()
        {
            if (_contentFrame.CanGoBack)
            {
                _contentFrame.GoBack();
            }
        }

        /// <summary>
        /// Осуществляет навигацию на необходимую странцу
        /// </summary>
        /// <param name="page">Открываемая страница</param>
        public void NavigateTo(PagesEnum page)
        {
            NavigateTo(page, null);
        }

        /// <summary>
        /// Осуществляет навигацию на необходимую странцу
        /// </summary>
        /// <param name="page">Открываемая страница</param>
        /// <param name="parameter">Параметр, передаваемый при навигации</param>
        public void NavigateTo(PagesEnum page, object parameter)
        {
            CurrentPage = page;
            Type neededType = _pages[page];
            _contentFrame.Navigate(neededType, parameter);
        }

        #endregion Public Methods
    }
}
