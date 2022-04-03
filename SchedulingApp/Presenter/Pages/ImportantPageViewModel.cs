using Microsoft.Toolkit.Mvvm.Input;
using SchedulingApp.Presenter.Pages.Base;
using System;

namespace SchedulingApp.Presenter.Pages
{
    /// <summary>
    /// Представляет данные для страницы, отображающие элементы списком.
    /// (Используются задачи, имеющие важный приоритет)
    /// </summary>
    internal class ImportantPageViewModel : BaseListPageViewModel
    {
        #region Private Properties

        /// <summary>
        /// Представляет реализацию синглтона для <see cref="ImportantPageViewModel"/>
        /// </summary>
        private static readonly Lazy<ImportantPageViewModel> _instance = new Lazy<ImportantPageViewModel>(() => new ImportantPageViewModel());

        #endregion Private Properties

        #region Public Properties

        /// <summary>
        /// Предоставляет доступ к экземпляру <see cref="ImportantPageViewModel"/>
        /// </summary>
        public static ImportantPageViewModel Instance => _instance.Value;

        #endregion Public Properties

        #region Private Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="ImportantPageViewModel"/>
        /// </summary>
        private ImportantPageViewModel() : base()
        {
        }

        protected override void LoadMissions()
        {
            //throw new NotImplementedException();
        }

        #endregion Private Constructors
    }
}
