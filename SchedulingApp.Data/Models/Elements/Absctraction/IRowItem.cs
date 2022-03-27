namespace SchedulingApp.Data.Models.Abstraction
{
    /// <summary>
    /// Интерфейс, представляющий данные строки, при описании задачи
    /// </summary>
    public interface IRowItem
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
