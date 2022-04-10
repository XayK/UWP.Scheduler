using SchedulingApp.Data.Models;
using SchedulingApp.Data.Services;
using SchedulingApp.Data.Storages;
using SchedulingApp.Presenter.Entities;
using SchedulingApp.Presenter.Pages.Abstraction;
using SchedulingApp.Presenter.Pages.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchedulingApp.Presenter.Pages
{
    /// <summary>
    /// Представляет данные для страницы календаря
    /// </summary>
    public class CalendarPageViewModel : ICalendarPageViewModel
    {

        #region Private Fields

        /// <summary>
        /// Представляет реализацию синглтона для <see cref="CalendarPageViewModel"/>
        /// </summary>
        private static readonly Lazy<CalendarPageViewModel> _instance = new Lazy<CalendarPageViewModel>(() => new CalendarPageViewModel());

        #endregion Private Fields

        #region Internal Properties

        /// <summary>
        /// Представляет коллекцию отображаемых задач
        /// </summary>
        internal ObservableCollection<MissionViewModel> Missions { get; }

        #endregion Internal Properties

        #region Public Properties

        /// <summary>
        /// Предоставляет доступ к экземпляру <see cref="CalendarPageViewModel"/>
        /// </summary>
        public static CalendarPageViewModel Instance => _instance.Value;
        /// <summary>
        /// Представляет или задает день конца месяца
        /// </summary>
        public DateTime EndMonth { get; private set; }

        /// <summary>
        /// Представляет или задает день начала месяца
        /// </summary>
        public DateTime StartMonth { get; private set; }

        #endregion Public Properties

        #region Private Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="CalendarPageViewModel"/>
        /// </summary>
        private CalendarPageViewModel() : base()
        {
            Missions = new ObservableCollection<MissionViewModel>();
            StartMonth = new DateTime(2022,4,1);
            EndMonth = new DateTime(2022,4,30);
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Осуществляет загрузку данных заданного месяца
        /// </summary>
        public void LoadMonth()
        {
            MissionStorage storage = DatabaseLocatorService.Instance.MissionsStorage;
            IEnumerable<Mission> missions = storage.GetAll();
            missions = missions.Where(mission => mission.StartDateTime < EndMonth && mission.EndDateTime > StartMonth);

            foreach (var mission in missions)
            {
                Missions.Add(new MissionViewModel(mission));
            }
        }

        #endregion Public Methods
    }
}
