using SchedulingApp.Presenter.Pages.Base;
using System;

namespace SchedulingApp.Presenter.Pages
{
    /// <summary>
    /// Представляет данные для страницы календаря
    /// </summary>
    public class CalendarPageViewModel : BaseTaskPageViewModel
    {
        #region Private Fields

        /// <summary>
        /// Представляет реализацию синглтона для <see cref="CalendarPageViewModel"/>
        /// </summary>
        private Lazy<CalendarPageViewModel> _instance = new Lazy<CalendarPageViewModel>(() => new CalendarPageViewModel());

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Предоставляет доступ к экземпляру <see cref="CalendarPageViewModel"/>
        /// </summary>
        public static CalendarPageViewModel Instance => _instance.Value;

        #endregion Public Properties

        #region Private Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="CalendarPageViewModel"/>
        /// </summary>
        private CalendarPageViewModel() : base()
        {

        }

        #endregion Private Constructors
    }
}
