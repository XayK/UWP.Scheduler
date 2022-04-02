using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SchedulingApp.Presenter.Entities.Abstraction;
using SchedulingApp.Presenter.Pages.Abstraction;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchedulingApp.Presenter.Pages.Base
{
    /// <summary>
    /// Базовый класс представления данных для страницы, отображающие элементы списком
    /// </summary>
    public abstract class BaseListPageViewModel : ObservableObject
    {
        #region Public Properties

        /// <summary>
        /// Предосталяет комманду создания миссии
        /// </summary>
        public ICommand CreateCommand { get; }

        /// <summary>
        /// Предосталяет комманду удаления выбранной миссии
        /// </summary>
        public ICommand DeleteCommand { get; }

        /// <summary>
        /// Предосталяет комманду правки выбранной миссии
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// Предоставляет коллекцию <see cref="IMissionViewModel"/>, задач для отображения
        /// </summary>
        public ObservableCollection<IMissionViewModel> Missions { get; }

        /// <summary>
        /// Предоставляет или задает текущий выбранный элемент <see cref="IMissionViewModel"/>
        /// </summary>
        public IMissionViewModel SelectedMission { get; set; }

        #endregion Public Properties

        #region Protected Constructors

        /// <summary>
        /// Инициализирует наследуемые поля <see cref="BaseListPageViewModel"/>
        /// </summary>
        /// <param name="createCommand">Комманада создания задачи</param>
        /// <param name="editCommand">Комманда правки задачи</param>
        /// <param name="deleteCommand">Комманда удаления задачи</param>
        protected BaseListPageViewModel(RelayCommand createCommand, RelayCommand editCommand, RelayCommand deleteCommand)
        {
            CreateCommand = createCommand;
            EditCommand = editCommand;
            DeleteCommand = deleteCommand;

            Missions = new ObservableCollection<IMissionViewModel>();
        }

        #endregion Protected Constructors
    }
}
