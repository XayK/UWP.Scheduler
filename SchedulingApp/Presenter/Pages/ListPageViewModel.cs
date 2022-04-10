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
    /// Представляет данные для страницы, отображающие элементы списком
    /// </summary>
    public class ListPageViewModel : BaseListPageViewModel, IListPageViewModel
    {
        #region Private Properties

        /// <summary>
        /// Представляет реализацию синглтона для <see cref="ListPageViewModel"/>
        /// </summary>
        private static readonly Lazy<ListPageViewModel> _instance = new Lazy<ListPageViewModel>(() => new ListPageViewModel());

        #endregion Private Properties

        #region Public Properties

        /// <summary>
        /// Предоставляет доступ к экземпляру <see cref="ListPageViewModel"/>
        /// </summary>
        public static ListPageViewModel Instance => _instance.Value;

        #endregion Public Properties

        #region Private Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="ListPageViewModel"/>
        /// </summary>
        private ListPageViewModel() : base()
        { }

        #endregion Private Constructors

        /// <summary> <inheritdoc/> </summary>
        protected override void LoadMissions()
        {
            if (Missions.Any())
            {
                return;
            }

            MissionStorage storage = DatabaseLocatorService.Instance.MissionsStorage;
            IEnumerable<Mission> missions = storage.GetAll();

            foreach (var mission in missions)
            {
                Missions.Add(new MissionViewModel(mission));
            }
        }
    }
}
