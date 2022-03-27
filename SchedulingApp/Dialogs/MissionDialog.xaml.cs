using SchedulingApp.Dialogs.Base;
using Windows.UI.Xaml;

namespace SchedulingApp.Dialogs
{
    /// <summary>
    /// Представляет диалог для создания/редактирования задачи
    /// </summary>
    internal sealed partial class MissionDialog : DialogBase
    {
        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="MissionDialog"/>
        /// </summary>
        public MissionDialog()
        {
            this.InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Обработка нажатия кнопки отмены
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            base.SetNoteResult();
        }

        /// <summary>
        /// Обработка нажатия кнопки сохранения
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            base.SetPrimaryResult();
        }

        #endregion Private Methods
    }
}
