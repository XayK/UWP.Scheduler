namespace SchedulingApp.Services.Abstraction
{
    /// <summary>
    /// Представляет интерфейс 
    /// </summary>
    internal interface INavigationService
    {
        #region Public Properties

        /// <summary>
        /// Представляет текущую страницу
        /// </summary>
        PagesEnum CurrentPage { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Осуществляет навигацию по стеку страниц назад
        /// </summary>
        public void GoBack();

        /// <summary>
        /// Осуществляет навигацию на указанную страницу
        /// </summary>
        /// <param name="page">Тип указываемой страницы</param>
        public void NavigateTo(PagesEnum page);

        /// <summary>
        /// Осуществляет навигацию на указанную страницу
        /// </summary>
        /// <param name="page">Тип указываемой страницы</param>
        /// <param name="parameter">Параметр страницы, передаваемый при навигации</param>
        public void NavigateTo(PagesEnum page, object parameter);

        #endregion Public Methods
    }
}
