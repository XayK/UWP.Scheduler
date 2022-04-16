using SchedulingApp.Dialogs.Base;
using Windows.UI.Xaml;

namespace SchedulingApp.Dialogs
{
    /// <summary>
    /// Представляет или задает диалог подтверждения операции
    /// </summary>
    internal sealed partial class ConfirmationDialog : DialogBase
    {
        /// <summary>
        /// Представляет или задает текст на странице диалога
        /// </summary>
        public string DialogText { get; set; }

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="ConfirmationDialog"/>
        /// </summary>
        public ConfirmationDialog()
        {
            this.InitializeComponent();
            DialogText = "Want to delete ?";
        }

        #endregion Public Constructors

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
    }
}
