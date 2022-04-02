using Microsoft.Toolkit.Mvvm.ComponentModel;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Presenter.Entities.Abstraction;

namespace SchedulingApp.Presenter.Entities.Elements.Base
{
    /// <summary>
    /// Базовый класс, для представления данных строки в описании задачи
    /// </summary>
    internal abstract class BaseRowItemViewModel : ObservableObject, IEntityViewModel<IRowItem>, IRowItemViewModel
    {
        #region Public Properties

        /// <summary> <inheritdoc/> </summary>
        public bool IsChecked { get; set; }

        /// <summary> <inheritdoc/> </summary>
        public bool IsCheckEnabled { get; set; }

        /// <summary>
        /// Предоставляет модель данных <see cref="IRowItem"/>, используя представление
        /// </summary>
        public abstract IRowItem Model { get; }

        /// <summary> <inheritdoc/> </summary>
        public string Text { get; set; }

        #endregion Public Properties

        #region Protected Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="BaseRowItemViewModel"/>
        /// </summary>
        /// <param name="rowItem">Модель данных</param>
        protected BaseRowItemViewModel(IRowItem rowItem)
        {
            IsChecked = rowItem.IsChecked;
            IsCheckEnabled = rowItem.IsCheckable;
            Text = rowItem.Text;
        }

        #endregion Protected Constructors
    }
}
