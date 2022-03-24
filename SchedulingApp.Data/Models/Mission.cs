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
        /// Предоставляет или задает краткое описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Предоставляет или задает флаг необходимости отображения списка задач
        /// </summary>
        public bool IsListNeeded { get; set; }

        /// <summary>
        /// Предоставляет или задает список задач
        /// </summary>
        public List<string> ToDoList { get; set; }

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
