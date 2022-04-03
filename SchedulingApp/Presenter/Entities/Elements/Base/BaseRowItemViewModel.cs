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
        #region Private Fields

        /// <summary>
        /// Предоставляет или задает флаг задачи как выполненнной
        /// </summary>
        private bool _isChecked;

        /// <summary>
        /// Предоставляет или задает флаг возможности отслеживания прогресса строки в задаче
        /// </summary>
        private bool _isCheckEnabled;

        /// <summary>
        /// Предоставляет или задает текст описания строки задачи
        /// </summary>
        private string _text;

        #endregion Private Fields

        #region Public Properties

        /// <summary> <inheritdoc/> </summary>
        public bool IsChecked 
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }

        /// <summary> <inheritdoc/> </summary>
        public bool IsCheckEnabled
        {
            get => _isCheckEnabled;
            set => SetProperty(ref _isCheckEnabled, value);
        }

        /// <summary> <inheritdoc/> </summary>
        public abstract IRowItem Model { get; }

        /// <summary> <inheritdoc/> </summary>
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

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
