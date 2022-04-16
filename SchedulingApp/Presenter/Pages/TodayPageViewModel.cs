using SchedulingApp.Data.Models;
using SchedulingApp.Data.Services;
using SchedulingApp.Data.Storages;
using SchedulingApp.Presenter.Entities;
using SchedulingApp.Presenter.Pages.Abstraction;
using SchedulingApp.Presenter.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchedulingApp.Presenter.Pages
{
    /// <summary>
    /// Представляет данные для страницы, отображающие элементы списком.
    /// (Используются задачи, которые должны выполнятся сегодня)
    /// </summary>
    internal class TodayPageViewModel : BaseListPageViewModel, IListPageViewModel
    {
        #region Private Fields

        /// <summary>
        /// Представляет реализацию синглтона для <see cref="TodayPageViewModel"/>
        /// </summary>
        private static readonly Lazy<TodayPageViewModel> _instance = new Lazy<TodayPageViewModel>(() => new TodayPageViewModel());

        #endregion Private Fields

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
        { }
        #endregion Private Constructors

        #region Protected Methods

        /// <summary> <inheritdoc/> </summary>
        protected override void LoadMissions()
        {
            if (Missions.Any())
            {
                return;
            }

            MissionStorage storage = DatabaseLocatorService.Instance.MissionsStorage;
            IEnumerable<Mission> missions = storage.GetAll().Where
                (mission =>
                mission.StartDateTime.Date <= DateTime.Today
                &&
                mission.EndDateTime.Date >= DateTime.Today);

            foreach (var mission in missions)
            {
                Missions.Add(new MissionViewModel(mission));
            }
        }

        #endregion Protected Methods

        #region Public Methods

        /// <summary>
        /// Осуществляет перезагрузку всех данных
        /// </summary>
        public void ReloadMissions()
        {
            Missions.Clear();
            LoadMissions();
        }

        #endregion Public Methods
    }
}
