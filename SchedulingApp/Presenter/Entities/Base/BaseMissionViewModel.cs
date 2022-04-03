using Microsoft.Toolkit.Mvvm.ComponentModel;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Data.Models.Elements;
using SchedulingApp.Presenter.Entities.Abstraction;
using SchedulingApp.Presenter.Entities.Elements;
using System;
using System.Collections.ObjectModel;

namespace SchedulingApp.Presenter.Entities.Base
{
    /// <summary>
    /// Базовый класс, для представления данных о задаче
    /// </summary>
    internal abstract class BaseMissionViewModel : ObservableObject, IEntityViewModel<IMission>, IMissionViewModel
    {
        #region Private Fields

        /// <summary>
        /// Предоставляет или задает дату/время окончания задачи
        /// </summary>
        private DateTime _endDateTime;

        /// <summary>
        /// Предоставляет или задает флаг важности задачи
        /// </summary>
        private bool _isImportant;

        /// <summary>
        /// Предоставляет или задает дату/время начала задачи
        /// </summary>
        private DateTime _startDateTime;

        /// <summary>
        /// Предоставляет или задает заголвок названия задачи
        /// </summary>
        private string _title;

        #endregion Private Fields

        #region Protected Fields

        /// <summary>
        /// Предоставляет идентификатор задачи
        /// </summary>
        protected readonly string _id;

        #endregion Protected Fields

        #region Public Properties

        /// <summary> <inheritdoc/> </summary>
        public ObservableCollection<IRowItemViewModel> Descriptions { get; }

        /// <summary> <inheritdoc/> </summary>
        public DateTime EndDateTime 
        {
            get => _endDateTime;
            set => SetProperty(ref _endDateTime, value);
        }

        /// <summary> <inheritdoc/> </summary>
        public bool IsImportant
        {
            get => _isImportant;
            set => SetProperty(ref _isImportant, value);
        }

        /// <summary>
        /// Предоставляет модель данных <see cref="IMission"/> представления
        /// </summary>
        public abstract IMission Model { get; }

        /// <summary> <inheritdoc/> </summary>
        public DateTime StartDateTime
        {
            get => _startDateTime;
            set => SetProperty(ref _startDateTime, value);
        }

        /// <summary> <inheritdoc/> </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        #endregion Public Properties

        #region Protected Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="BaseMissionViewModel"/>
        /// </summary>
        /// <param name="mission">Модель данных</param>
        protected BaseMissionViewModel(IMission mission)
        {
            if(string.IsNullOrEmpty(mission.Id))
            {
                _id = Guid.NewGuid().ToString();
            }
            else
            {
                _id = mission.Id;
            }

            StartDateTime = mission.StartDateTime;
            EndDateTime = mission.EndDateTime;
            Title = mission.Title;

            Descriptions = new ObservableCollection<IRowItemViewModel>();
            foreach(var rowItem in mission.Descriptions)
            {
                IRowItemViewModel rowPresenter = new RowItemViewModel(rowItem as RowItem);
                Descriptions.Add(rowPresenter);
            }
        }

        #endregion Protected Constructors

    }
}
