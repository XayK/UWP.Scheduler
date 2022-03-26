using SchedulingApp.Presenter.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp.Presenter.Pages
{
    /// <summary>
    /// Представляет данные для страницы, отображающие элементы списком.
    /// (Используются задачи, которые должны выполнятся сегодня)
    /// </summary>
    internal class TodayPageViewModel : BaseListPageViewModel
    {
        #region Private Properties

        /// <summary>
        /// Представляет реализацию синглтона для <see cref="TodayPageViewModel"/>
        /// </summary>
        private readonly static Lazy<TodayPageViewModel> _instance = new Lazy<TodayPageViewModel>(() => new TodayPageViewModel());

        #endregion Private Properties

        #region Public Properties

        /// <summary>
        /// Предоставляет доступ к экземпляру <see cref="TodayPageViewModel"/>
        /// </summary>
        public static TodayPageViewModel Instance => _instance.Value;

        #endregion Public Properties

        #region Private Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="TodayPageViewModel"/>
        /// </summary>
        private TodayPageViewModel() : base()
        {

        }

        #endregion Private Constructors
    }
}
