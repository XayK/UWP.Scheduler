using Microsoft.Toolkit.Mvvm.ComponentModel;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Presenter.Entities.Abstraction;

namespace SchedulingApp.Presenter.Entities.Base
{
    /// <summary>
    /// Базовый класс, для представления данных о задаче
    /// </summary>
    internal abstract class BaseMissionViewModel : ObservableObject, IEntityViewModel<IMission>, IMissionViewModel
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="BaseMissionViewModel"/>
        /// </summary>
        protected BaseMissionViewModel()
        {
        }

        /// <summary>
        /// Предоставляет модель данных <see cref="IMission"/> представления
        /// </summary>
        public abstract IMission Model { get; }
    }
}
