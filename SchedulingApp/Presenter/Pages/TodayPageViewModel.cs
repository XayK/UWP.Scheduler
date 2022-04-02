using Microsoft.Toolkit.Mvvm.Input;
using SchedulingApp.Presenter.Pages.Base;
using System;

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
        private static readonly Lazy<TodayPageViewModel> _instance = new Lazy<TodayPageViewModel>(() => new TodayPageViewModel());

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
        private TodayPageViewModel() : base(new RelayCommand(CreateMission), new RelayCommand(EditSelectedMission), new RelayCommand(DeleteSelectedMission))
        {
        }

        /// <summary>
        /// Вызод удаления выбранной задачи
        /// </summary>
        private static void DeleteSelectedMission()
        {
            ///TODO: удалить выбранную задачу
        }

        /// <summary>
        /// Вызов правки выбранной задачи
        /// </summary>
        private static void EditSelectedMission()
        {
            ///TODO: вызвать диалог правки выбранной задачу
        }

        /// <summary>
        /// Создание новой задачи
        /// </summary>
        private static void CreateMission()
        {
            ///TODO: создать задачу
        }

        #endregion Private Constructors
    }
}
