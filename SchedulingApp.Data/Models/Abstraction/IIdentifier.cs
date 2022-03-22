using System.ComponentModel.DataAnnotations;

namespace SchedulingApp.Data.Models.Abstraction
{
    internal interface IIdentifier
    {
        [Key]
        /// <summary>
        /// Предоставляет или задает идентификатор
        /// </summary>
        public string Id { get; set; }
    }
}
