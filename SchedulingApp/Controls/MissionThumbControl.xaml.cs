using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace SchedulingApp.Controls
{
    /// <summary>
    /// Представляет контрол для отобрадения задачи в списке
    /// </summary>
    public sealed partial class MissionThumbControl : UserControl
    {
        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="MissionThumbControl"/>
        /// </summary>
        public MissionThumbControl()
        {
            this.InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Обработка события входа указателя в область контрола
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Control_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            BorderBackground.Opacity = 0.2;
        }

        /// <summary>
        /// Обработка события выхода указателя из области контрола
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Control_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            BorderBackground.Opacity = 0.1;
        }

        #endregion Private Methods
    }
}
