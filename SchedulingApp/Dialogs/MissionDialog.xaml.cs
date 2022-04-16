using SchedulingApp.Data.Models;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Data.Models.Elements;
using SchedulingApp.Dialogs.Base;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace SchedulingApp.Dialogs
{
    /// <summary>
    /// Представляет диалог для создания/редактирования задачи
    /// </summary>
    internal sealed partial class MissionDialog : DialogBase
    {
        #region Public Properties

        /// <summary>
        /// Предоставляет или задает дату окончания задачи
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Предоставляет заголовок окна диалога
        /// </summary>
        public string TitleDialog { get; }

        /// <summary>
        /// Представляет или задает временя начала задачи
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// Предоставляет или задает флаг важной задачи
        /// </summary>
        public bool IsImportant { get; set; }

        /// <summary>
        /// Представляет или задает дату начала задачи
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Представляет или задает временя начала задачи
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Предоставляет заголвок диалога
        /// </summary>
        public string MissionTitle { get; set; }

        /// <summary>
        /// Предоставляет данные в ввиде модели <see cref="Mission"/>
        /// </summary>
        public Mission ModelData => GetModelDate();

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="MissionDialog"/>
        /// </summary>
        /// <param name="titleDialog">Заголовок диалогового окна</param>
        public MissionDialog(string titleDialog)
        {
            TitleDialog = titleDialog;

            Title = string.Empty;
            StartDate = DateTime.Now.Date;
            StartTime = TimeSpan.FromHours(1);
            EndDate = DateTime.Now.Date;
            EndTime = TimeSpan.FromHours(23);

            this.InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Предоставляет данные из диалога в виде модели данных
        /// </summary>
        /// <returns>Модель данных <see cref="Mission"/></returns>
        private Mission GetModelDate()
        {
            Mission model = new Mission();

            model.Title = MissionTitle;
            model.StartDateTime = StartDate + StartTime;
            model.EndDateTime = EndDate + EndTime;
            model.Descriptions = new Collection<IRowItem>()
            {
                new RowItem()
            };
            model.IsImportant = IsImportant;

            return model;
        }

        /// <summary>
        /// Обработка нажатия кнопки отмены
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            base.SetNoneResult();
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
