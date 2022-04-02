using SchedulingApp.Data.Models;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Data.Models.Elements;
using SchedulingApp.Dialogs.Base;
using SchedulingApp.Presenter.Entities.Abstraction;
using SchedulingApp.Presenter.Entities.Elements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        /// Предоставляет описание действий в задаче
        /// </summary>
        public ICollection<IRowItemViewModel> Descriptions { get; }

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
        /// Предоставляет или задает выбранную строку в описании
        /// </summary>
        public IRowItemViewModel SelectedDescription { get; set; }

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
        /// Предоставляет данные в ввиде модели <see cref="IMission"/>
        /// </summary>
        public IMission ModelData => GetModelDate();

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="MissionDialog"/>
        /// </summary>
        public MissionDialog()
        {
            Title = string.Empty;
            StartDate = DateTime.Now.Date;
            StartTime = TimeSpan.FromHours(1);
            EndDate = DateTime.Now.Date;
            EndTime = TimeSpan.FromHours(23);

            Descriptions = new List<IRowItemViewModel>();

            this.InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Предоставляет данные из диалога в виде модели данных
        /// </summary>
        /// <returns>Модель данных <see cref="IMission"/></returns>
        private IMission GetModelDate()
        {
            IMission model = new Mission();

            model.Title = MissionTitle;
            model.StartDateTime = StartDate + StartTime;
            model.EndDateTime = EndDate + EndTime;

            IEnumerable<IRowItem> decriptions = Descriptions.Select(x =>
                new RowItem()
                {
                    IsCheckable = x.IsCheckEnabled,
                    IsChecked = x.IsChecked,
                    Text = x.Text
                }
            );

            model.Descriptions = new Collection<IRowItem>(decriptions.ToList());

            return model;
        }

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
        /// Обработка изменения состояния переключателя описания задачи
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void DesciptionToggle_Switched(object sender, RoutedEventArgs e)
        {
            if (SelectedDescription != null)
            {
                SelectedDescription.IsCheckEnabled = !SelectedDescription.IsCheckEnabled;
            }
        }

        /// <summary>
        /// Обработка клика кнопки добавления новой строки описания
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void NewDescription_Click(object sender, RoutedEventArgs e)
        {
            RowItem model = new ();
            RowItemViewModel presenter = new (model);
            Descriptions.Add(presenter);
            SelectedDescription = presenter;

            Bindings.Update();
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
