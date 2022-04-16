using SchedulingApp.Dialogs.Base;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

namespace SchedulingApp.Dialogs
{
    /// <summary>
    /// Представляет или задает диалог подтверждения операции
    /// </summary>
    internal sealed partial class ConfirmationDialog : DialogBase
    {
        #region Public Properties

        /// <summary>
        /// Представляет или задает текст на странице диалога
        /// </summary>
        public string DialogText { get; set; }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="ConfirmationDialog"/>
        /// </summary>
        public ConfirmationDialog()
        {
            this.InitializeComponent();

            var resourceLoader = ResourceLoader.GetForCurrentView();
            DialogText = resourceLoader.GetString("confirmation_delete_content");
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Обработка клика по кнопка отказа
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            base.SetNoneResult();
        }

        /// <summary>
        /// Обработка клика по кнопка подтверждения
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            base.SetPrimaryResult();
        }

        #endregion Private Methods
    }
}
