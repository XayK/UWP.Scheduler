using SchedulingApp.Data.Models.Abstraction;

namespace SchedulingApp.Data.Models.Elements
{
    /// <summary>
    /// Предствляет данные об строке, описывающий задание в расписании
    /// </summary>
    public class RowItem : IRowItem
    {
        /// <summary>
        /// Предоставляет или задает наличие возможности установки флага "сделано"/"не сделано" 
        /// </summary>
        public bool IsCheckable { get; set; }

        /// <summary>
        /// Предоставляет или задает флаг состояния задачи, как "сделано"
        /// </summary>
        public bool IsChecked { get; set; }

        /// <summary>
        /// Предоставляет или задает текст описания
        /// </summary>
        public string Text { get; set; }
    }
}
