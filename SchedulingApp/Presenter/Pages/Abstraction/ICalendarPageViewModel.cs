using System;
using System.Windows.Input;

namespace SchedulingApp.Presenter.Pages.Abstraction
{
    /// <summary>
    /// Интерфейс, реализующий представление данных задач на странице с помощью календаря
    /// </summary>
    internal interface ICalendarPageViewModel
    { 
        /// <summary>
        /// Представляет или задает день месяца
        /// </summary>
        public DateTime DateMonth { get;}

        /// <summary>
        /// Представляет день конца месяца
        /// </summary>
        public DateTime EndMonth { get; }

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
        public DateTime StartMonth { get; }

        /// <summary>
        /// Осуществляет загрузку данных заданного месяца
        /// </summary>
        public void LoadMonth();
    }
}
