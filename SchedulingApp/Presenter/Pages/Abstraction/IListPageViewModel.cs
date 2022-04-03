using SchedulingApp.Presenter.Entities.Abstraction;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchedulingApp.Presenter.Pages.Abstraction
{
    /// <summary>
    /// Интерфейс, реализующий представление данных задач на странице с помощью списка
    /// </summary>
    internal interface IListPageViewModel
    {
        #region Public Properties

        /// <summary>
        /// Предосталяет комманду создания задачи
        /// </summary>
        public ICommand CreateCommand { get; }

        /// <summary>
        /// Предосталяет комманду удаления выбранной задачи
        /// </summary>
        public ICommand DeleteCommand { get; }

        /// <summary>
        /// Предосталяет комманду правки выбранной задачи
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// Предосталяет комманду работы с описанием выбранной задачи
        /// </summary>
        public ICommand ShowDescriptionsCommand { get; }

        /// <summary>
        /// Предоставляет коллекцию <see cref="IMissionViewModel"/>, задач для отображения
        /// </summary>
        public ObservableCollection<IMissionViewModel> Missions  { get; }

        /// <summary>
        /// Предоставляет или задает текущий выбранный элемент <see cref="IMissionViewModel"/>
        /// </summary>
        public IMissionViewModel SelectedMission { get; set; }

        #endregion Public Properties
    }
}
