using SchedulingApp.Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingApp.Presenter.Entities.Abstraction
{
    /// <summary>
    /// Представляет интерфейс для ViewModel'и задачи в расписании
    /// </summary>
    public interface IMissionViewModel
    {
        /// <summary>
        /// Предоставляет или задает заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Предоставляет или задает контент, представляющий описание сущности
        /// </summary>
        public ObservableCollection<IRowItem> Descriptions { get; }

        /// <summary>
        /// Предоставляет или задает дату и время начала
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Предоставляет или задает дату и время окончания
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Предоставляет модель данных <see cref="IMission"/> представления
        /// </summary>
        public IMission Model { get; }
    }
}
