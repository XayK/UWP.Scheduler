using SchedulingApp.Data.Models;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Data.Models.Elements;
using SchedulingApp.Dialogs.Base;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
        /// Представляет или задает временя начала задачи
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// Предоставляет или задает флаг важной задачи
        /// </summary>
        public bool IsImportant { get; set; }

        /// <summary>
        /// Предоставляет заголвок диалога
        /// </summary>
        public string MissionTitle { get; set; }

        /// <summary>
        /// Предоставляет данные в ввиде модели <see cref="Mission"/>
        /// </summary>
        public Mission ModelData => GetModelDate();

        /// <summary>
        /// Представляет или задает дату начала задачи
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Представляет или задает временя начала задачи
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Предоставляет заголовок окна диалога
        /// </summary>
        public string TitleDialog { get; }

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
        /// Обработка нажатия кнопки отмены
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            base.SetNoneResult();
        }

        /// <summary>
        /// Обработка события изменения даты конца задачи
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void EndDate_Changed(object sender, DatePickerValueChangedEventArgs e)
        {
            EndDate = e.NewDate.DateTime;
            DateTime end = GetDateTime(EndDate, EndTime);
            DateTime start = GetDateTime(StartDate, StartTime);

            if (end - start < TimeSpan.FromMinutes(1))
            {
                start = end - TimeSpan.FromMinutes(2);
                StartDate = start.Date;
                StartTime = start.TimeOfDay;
                Bindings.Update();
            }
        }

        /// <summary>
        /// Обработка события изменения времени конца задачи
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void EndTime_Changed(object sender, TimePickerValueChangedEventArgs e)
        {
            EndTime = e.NewTime;
            DateTime end = GetDateTime(EndDate, EndTime);
            DateTime start = GetDateTime(StartDate, StartTime);

            if (end - start < TimeSpan.FromMinutes(1))
            {
                start = end - TimeSpan.FromMinutes(2);
                StartDate = start.Date;
                StartTime = start.TimeOfDay;
                Bindings.Update();
            }
        }

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
        /// Обработка нажатия кнопки сохранения
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            base.SetPrimaryResult();
        }

        private DateTime GetDateTime(DateTime date, TimeSpan time)
        {
            return date.Date + time;
        }

        /// <summary>
        /// Обработка события изменения даты начала задачи
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void StartDate_Changed(object sender, DatePickerValueChangedEventArgs e)
        {
            StartDate = e.NewDate.DateTime;
            DateTime end = GetDateTime(EndDate, EndTime);
            DateTime start = GetDateTime(StartDate, StartTime);

            if (end - start < TimeSpan.FromMinutes(1))
            {
                end = start + TimeSpan.FromMinutes(2);
                EndDate = end.Date;
                EndTime = end.TimeOfDay;
                Bindings.Update();
            }
        }

        /// <summary>
        /// Обработка события изменения времени начала задачи
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void StartTime_Changed(object sender, TimePickerValueChangedEventArgs e)
        {
            StartTime = e.NewTime;
            DateTime end = GetDateTime(EndDate, EndTime);
            DateTime start = GetDateTime(StartDate, StartTime);

            if (end - start < TimeSpan.FromMinutes(1))
            {
                end = start + TimeSpan.FromMinutes(2);
                EndDate = end.Date;
                EndTime = end.TimeOfDay;
                Bindings.Update();
            }
        }

        #endregion Private Methods
    }
}
