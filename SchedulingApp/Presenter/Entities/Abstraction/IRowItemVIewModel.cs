namespace SchedulingApp.Presenter.Entities.Abstraction
{
    /// <summary>
    /// Представляет интерфейс для ViewModel'и строки в задаче
    /// </summary>
    internal interface IRowItemViewModel
    {
        /// <summary>
        /// Предоставляет или задает наличие отметки прогресса у задача
        /// </summary>
        public bool IsCheckEnabled { get; set; }

        /// <summary>
        /// Предоставляет или задает флаг выполненности задачи
        /// </summary>
        public bool IsChecked { get; set; }

        /// <summary>
        /// Предоставляет или задает текст описания
        /// </summary>
        public string Text { get; set; }
    }
}
