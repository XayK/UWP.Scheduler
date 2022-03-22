using System;

namespace SchedulingApp.Data.Models.Abstraction
{
    public interface ITask : IIdentifier
    {
        /// <summary>
        /// Предоставляет или задает заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Предоставляет или задает краткое описание
        /// </summary>
        public string Description { get; set; }

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
