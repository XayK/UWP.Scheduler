using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SchedulingApp.Data.Models;
using SchedulingApp.Data.Services;
using SchedulingApp.Data.Storages;
using SchedulingApp.Presenter.Entities;
using SchedulingApp.Presenter.Pages.Abstraction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SchedulingApp.Presenter.Pages
{
    /// <summary>
    /// Представляет данные для страницы календаря
    /// </summary>
    public class CalendarPageViewModel : ObservableObject, ICalendarPageViewModel
    {
        #region Private Fields

        /// <summary>
        /// Представляет реализацию синглтона для <see cref="CalendarPageViewModel"/>
        /// </summary>
        private static readonly Lazy<CalendarPageViewModel> _instance = new Lazy<CalendarPageViewModel>(() => new CalendarPageViewModel());

        /// <summary>
        /// Представляет или задает день месяца
        /// </summary>
        private DateTime _dateMonth;

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
        /// Представляет или задает день месяца
        /// </summary>
        public DateTime DateMonth
        {
            get => _dateMonth;
            private set
            {
                SetProperty(ref _dateMonth, value);
                LoadMonth();
            }
        }

        /// <summary>
        /// Представляет день конца месяца
        /// </summary>
        public DateTime EndMonth => GetEndMonthDate();

        /// <summary>
        /// Представляет коммнаду переключения на следующий месяц
        /// </summary>
        public ICommand NextMonthCommand { get; }

        /// <summary>
        /// Представляет коммнаду переключения на предидущий месяц
        /// </summary>
        public ICommand PreviousMonthCommand { get; }

        /// <summary>
        /// Представляет день начала месяца
        /// </summary>
        public DateTime StartMonth => new DateTime(DateMonth.Year, DateMonth.Month, 1);

        #endregion Public Properties

        #region Private Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="CalendarPageViewModel"/>
        /// </summary>
        private CalendarPageViewModel() : base()
        {
            Missions = new ObservableCollection<MissionViewModel>();
            _dateMonth = DateTime.Now;

            NextMonthCommand = new RelayCommand(NextMonth);
            PreviousMonthCommand = new RelayCommand(PreviousMonth);
        }

        #endregion Private Constructors

        #region Private Methods

        /// <summary>
        /// Вычисление даты конца месяца
        /// </summary>
        /// <returns>Дату в виде <see cref="DateTime"/></returns>
        private DateTime GetEndMonthDate()
        {
            int endYear = DateMonth.Year;
            int endMonth = DateMonth.Month + 1;

            if (endMonth > 12)
            {
                endMonth = 1;
                endYear++;
            }

            return new DateTime(endYear, endMonth, 1);
        }

        /// <summary>
        /// Переключение на следущий месяц
        /// </summary>
        private void NextMonth()
        {
            int year = DateMonth.Year;
            int month = DateMonth.Month + 1;

            if (month > 12)
            {
                month = 1;
                year++;
            }

            DateMonth = new DateTime(year, month, 1);
        }

        /// <summary>
        /// Переключение на предидущий месяц
        /// </summary>
        private void PreviousMonth()
        {
            int year = DateMonth.Year;
            int month = DateMonth.Month - 1;

            if (month < 1)
            {
                month = 12;
                year--;
            }

            DateMonth = new DateTime(year, month, 1);
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// Осуществляет загрузку данных заданного месяца
        /// </summary>
        public void LoadMonth()
        {
            if (Missions.Any())
            {
                Missions.Clear();
            }

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
