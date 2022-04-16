using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SchedulingApp.Data.Models;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Data.Models.Elements;
using SchedulingApp.Data.Services;
using SchedulingApp.Data.Storages;
using SchedulingApp.Helper;
using SchedulingApp.Presenter.Entities;
using SchedulingApp.Presenter.Entities.Abstraction;
using SchedulingApp.Presenter.Entities.Elements;
using System.Collections.Generic;
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

        /// <summary>
        /// Предосталяет комманду работы с описанием выбранной задачи
        /// </summary>
        public ICommand ShowDescriptionsCommand { get; }

        #endregion Public Properties

        #region Protected Constructors

        /// <summary>
        /// Инициализирует наследуемые поля <see cref="BaseListPageViewModel"/>
        /// </summary>
        protected BaseListPageViewModel()
        {
            CreateCommand = new RelayCommand(CreateMission);
            EditCommand = new RelayCommand(EditSelectedMission);
            DeleteCommand = new RelayCommand(DeleteSelectedMission);
            ShowDescriptionsCommand = new RelayCommand(ShowDescriptions);

            Missions = new ObservableCollection<IMissionViewModel>();
            LoadMissions();
        }

        #endregion Protected Constructors

        #region Private Methods

        /// <summary>
        /// Создание новой задачи
        /// </summary>
        private async void CreateMission()
        {
            Mission model = await DialogExecutor.ShowMissionCreation();

            if (model == null)
            {
                return;
            }

            IMissionViewModel presenter = new MissionViewModel(model);
            Missions.Add(presenter);

            MissionStorage storage = DatabaseLocatorService.Instance.MissionsStorage;
            storage.Insert(presenter.Model);
        }

        /// <summary>
        /// Вызод удаления выбранной задачи
        /// </summary>
        private async void DeleteSelectedMission()
        {
            if (SelectedMission == null)
            {
                return;
            }

            if (await DialogExecutor.ConfirmationDialog() == false)
            {
                return;
            }

            MissionStorage storage = DatabaseLocatorService.Instance.MissionsStorage;
            storage.Remove(SelectedMission.Model.Id);

            Missions.Remove(SelectedMission);
        }

        /// <summary>
        /// Вызов правки выбранной задачи
        /// </summary>
        private async void EditSelectedMission()
        {
            if (SelectedMission == null)
            {
                return;
            }

            Mission model = await DialogExecutor.EditMission(SelectedMission.Model);

            if (model == null)
            {
                return;
            }

            SelectedMission.Title = model.Title;
            SelectedMission.IsImportant = model.IsImportant;
            SelectedMission.StartDateTime = model.StartDateTime;
            SelectedMission.EndDateTime = model.EndDateTime;

            MissionStorage storage = DatabaseLocatorService.Instance.MissionsStorage;
            storage.Update(SelectedMission.Model);
        }

        /// <summary>
        /// Вызов диалога правки описания задачи
        /// </summary>
        private async void ShowDescriptions()
        {
            if (SelectedMission == null)
            {
                return;
            }

            ICollection<IRowItem> model = await DialogExecutor.EditMissionDescription(SelectedMission.Model);

            if (model == null)
            {
                return;
            }

            SelectedMission.Descriptions.Clear();

            foreach (IRowItem item in model)
            {
                RowItemViewModel rowPresenter = new RowItemViewModel(item as RowItem);
                SelectedMission.Descriptions.Add(rowPresenter);
            }

            MissionStorage storage = DatabaseLocatorService.Instance.MissionsStorage;
            storage.Update(SelectedMission.Model as Mission);
        }

        #endregion Private Methods

        #region Protected Methods

        /// <summary>
        /// Осущестлвяет загрузку заданий
        /// </summary>
        protected abstract void LoadMissions();

        #endregion Protected Methods
    }
}
