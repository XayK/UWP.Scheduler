using Microsoft.Toolkit.Mvvm.ComponentModel;
using SchedulingApp.Data.Models.Abstraction;
using System.Collections.ObjectModel;

namespace SchedulingApp.Presenter.Pages.Base
{
    /// <summary>
    /// Базовый класс представления данных для страниц приложения,
    /// которые отображают данные о задач в расписании
    /// </summary>
    public abstract class BaseTaskPageViewModel : ObservableObject
    {
        /// <summary>
        /// Предоставляет используемые задачи
        /// </summary>
        public ObservableCollection<IMission> Missions { get; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="BaseTaskPageViewModel"/>
        /// </summary>
        protected BaseTaskPageViewModel()
        {
            Missions = new ObservableCollection<IMission>();
        }
    }
}
