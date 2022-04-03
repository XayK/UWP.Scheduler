using SchedulingApp.Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchedulingApp.Data.Models
{
    /// <summary>
    /// Преедсталвяет модель данных сущности - Задача.
    /// Является основным элементом данных 
    /// </summary>
    public class Mission : IMission
    {
        [Key]
        /// <summary>
        /// Предоставляет или задает идентификатор
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Предоставляет или задает заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Предоставляет или задает флаг как важной задачи
        /// </summary>
        public bool IsImportant { get; set; }

        /// <summary>
        /// Предоставляет или задает контент, представляющий описание задачи
        /// </summary>
        public ICollection<IRowItem> Descriptions { get; set; }

        /// <summary>
        /// Предоставляет или задает дату и время окончания
        /// </summary>
        public DateTime EndDateTime { get; set; }


        /// <summary>
        /// Предоставляет или задает дату и время начала
        /// </summary>
        public DateTime StartDateTime { get; set; }

    }
}
