using Microsoft.UI.Xaml.Controls;
using SchedulingApp.Dialogs;
using SchedulingApp.Services;
using SchedulingApp.Services.Abstraction;
using System;

namespace SchedulingApp
{
    /// <summary>
    /// Основная страница приложения.
    /// Содержит <see cref="Frame"/> контент и элементы навигации приложения
    /// </summary>
    public sealed partial class MainPage : Windows.UI.Xaml.Controls.Page
    {
        /// <summary>
        /// Предоставляет сервис навигации для контента страницы
        /// </summary>
        private readonly INavigationService _navigation;

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="MainPage"/>
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            _navigation = new NavigationService(MainFrame);
            _navigation.NavigateTo(PagesEnum.ListPageType);
        }

        #endregion Public Constructors

        /// <summary>
        /// Обработка события изменения текущего элемента
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="args">Аргуементы</param>
        private async void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var navigationItem = (NavigationViewItem)sender.SelectedItem;
            string tag = navigationItem.Tag.ToString();
            bool isParsed = int.TryParse(tag, out int pageId);

            if (isParsed)
            {
                _navigation.NavigateTo((PagesEnum)pageId);
            }
            else if(tag == "Settings")
            {
                SettingsDialog settingsDialog = new SettingsDialog();
                await settingsDialog.ShowAsync();
            }
        }
    }
}
