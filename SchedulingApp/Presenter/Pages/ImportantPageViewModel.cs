using SchedulingApp.Data.Models;
using SchedulingApp.Data.Services;
using SchedulingApp.Data.Storages;
using SchedulingApp.Presenter.Entities;
using SchedulingApp.Presenter.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;

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
        { }

        protected override void LoadMissions()
        {
            ///TODO: проверить
            if (Missions.Any())
            {
                return;
            }

            MissionStorage storage = DatabaseLocatorService.Instance.MissionsStorage;
            IEnumerable<Mission> missions = storage.GetAll().Where
                (mission => mission.EndDateTime >= DateTime.Now && mission.StartDateTime <= DateTime.Now);

            foreach (var mission in missions)
            {
                Missions.Add(new MissionViewModel(mission));
            }
        }

        #endregion Private Constructors
    }
}
