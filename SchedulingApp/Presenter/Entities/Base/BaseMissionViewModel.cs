using Microsoft.Toolkit.Mvvm.ComponentModel;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Presenter.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingApp.Presenter.Entities.Base
{
    /// <summary>
    /// Базовый класс, для представления данных о задаче
    /// </summary>
    internal abstract class BaseMissionViewModel : ObservableObject, IEntityViewModel<IMission>, IMissionViewModel
    {
        #region Public Properties

        /// <summary> <inheritdoc/> </summary>
        public ObservableCollection<IRowItem> Descriptions { get; }

        /// <summary> <inheritdoc/> </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Предоставляет модель данных <see cref="IMission"/> представления
        /// </summary>
        public abstract IMission Model { get; }

        /// <summary> <inheritdoc/> </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary> <inheritdoc/> </summary>
        public string Title { get; set; }

        #endregion Public Properties

        #region Protected Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="BaseMissionViewModel"/>
        /// </summary>
        /// <param name="mission">Модель данных</param>
        protected BaseMissionViewModel(IMission mission)
        {
            StartDateTime = mission.StartDateTime;
            EndDateTime = mission.EndDateTime;
            Title = mission.Title;

            Descriptions = new ObservableCollection<IRowItem>();
            foreach(var rowItem in mission.Descriptions)
            {
                Descriptions.Add(rowItem);
            }
        }

        #endregion Protected Constructors
    }
}
