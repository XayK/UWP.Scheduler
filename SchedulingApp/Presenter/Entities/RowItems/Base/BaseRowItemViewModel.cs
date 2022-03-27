using Microsoft.Toolkit.Mvvm.ComponentModel;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Presenter.Entities.Abstraction;

namespace SchedulingApp.Presenter.Entities.RowItems.Base
{
    /// <summary>
    /// Базовый класс, для представления данных строки в описании задачи
    /// </summary>
    internal abstract class BaseRowItemViewModel : ObservableObject, IEntityViewModel<IRowItem>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="BaseRowItemViewModel"/>
        /// </summary>
        protected BaseRowItemViewModel()
        {
        }

        /// <summary>
        /// Предоставляет модель данных <see cref="IRowItem"/>, используя представление
        /// </summary>

        public abstract IRowItem Model { get; }
    }
}
