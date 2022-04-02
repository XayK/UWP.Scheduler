using System;
using System.Collections.Generic;

namespace SchedulingApp.Data.Models.Abstraction
{
    public interface IMission : IIdentifier
    {
        /// <summary>
        /// Предоставляет или задает заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Предоставляет или задает контент, представляющий описание сущности
        /// </summary>
        public ICollection<IRowItem> Descriptions { get; set; }

        /// <summary>
        /// Предоставляет или задает флаг как важной задачи
        /// </summary>
        public bool IsImportant { get; set; }

        /// <summary>
        /// Предоставляет или задает дату и время начала
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Предоставляет или задает дату и время окончания
        /// </summary>
        public DateTime EndDateTime { get; set; }
    }
}

