using Microsoft.Toolkit.Mvvm.ComponentModel;
using SchedulingApp.Data.Models.Abstraction;
using System.Collections.ObjectModel;

namespace SchedulingApp.Presenter.Pages.Base
{
    /// <summary>
    /// Базовый класс представления данных для страниц приложения,
    /// которые отображают данные о задач в расписании
    /// </summary>
    internal abstract class BaseTaskPageViewModel : ObservableObject
    {
        /// <summary>
        /// Предоставляет используемые задачи
        /// </summary>
        public ObservableCollection<ITask> Missions { get; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="BaseTaskPageViewModel"/>
        /// </summary>
        protected BaseTaskPageViewModel()
        {
            Missions = new ObservableCollection<ITask>();
        }
    }
}
