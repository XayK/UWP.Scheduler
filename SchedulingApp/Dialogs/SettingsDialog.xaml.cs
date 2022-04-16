using SchedulingApp.Dialogs.Base;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace SchedulingApp.Dialogs
{
    /// <summary>
    /// Представляет или задает диалог для настроек приложения
    /// </summary>
    internal sealed partial class SettingsDialog : DialogBase
    {
        #region Public Properties

        /// <summary>
        ///// Представляет имя приложения
        /// </summary>
        public string AppName => GetAppName();

        /// <summary>
        /// Представляет версию приложения
        /// </summary>
        public string AppVersion => GetAppVertion();

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="SettingsDialog"/>
        /// </summary>
        public SettingsDialog()
        {
            this.InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Обработка клика по кнопка закрытий
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            base.SetNoneResult();
        }

        /// <summary>
        /// Получает название приложения
        /// </summary>
        /// <returns>Строку названия сборки</returns>
        private string GetAppName()
        {
            return AppInfo.Current.DisplayInfo.DisplayName;
        }

        /// <summary>
        /// Получает версию приложения
        /// </summary>
        /// <returns>Строку версии сборки</returns>
        private string GetAppVertion()
        {
            Package package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;

            return string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
        }

        #endregion Private Methods
    }
}
