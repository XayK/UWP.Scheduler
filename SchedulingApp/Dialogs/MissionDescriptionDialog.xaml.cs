using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Data.Models.Elements;
using SchedulingApp.Dialogs.Base;
using SchedulingApp.Presenter.Entities.Elements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SchedulingApp.Dialogs
{
    /// <summary>
    /// Представляет диалог работы с описанием задачи
    /// </summary>
    internal sealed partial class MissionDescriptionDialog : DialogBase
    {
        #region Public Properties

        /// <summary>
        /// Предоставляет описание действий в задаче
        /// </summary>
        public ObservableCollection<RowItemViewModel> Descriptions { get; }

        /// <summary>
        /// Предоставляет или задает выбранную строку в описании
        /// </summary>
        public RowItemViewModel SelectedDescription { get; set; }

        /// <summary>
        /// Предоставляет данные модели
        /// </summary>
        public ICollection<IRowItem> ModelData => GetModelDate();

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="MissionDescriptionDialog"/>
        /// </summary>
        public MissionDescriptionDialog()
        {
            this.InitializeComponent();

            Descriptions = new ObservableCollection<RowItemViewModel>();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Обработка изменения состояния переключателя описания задачи
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void DesciptionToggle_Switched(object sender, RoutedEventArgs e)
        {
            if (SelectedDescription == null)
            {
                return;
            }

            SelectedDescription.IsCheckEnabled = !SelectedDescription.IsCheckEnabled;
        }

        /// <summary>
        /// Обработка клика кнопки добавления новой строки описания
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void NewDescription_Click(object sender, RoutedEventArgs e)
        {
            RowItem model = new();
            RowItemViewModel presenter = new(model);
            Descriptions.Add(presenter);
            SelectedDescription = presenter;
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
        /// Обработка нажатия кнопки сохранения
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            base.SetPrimaryResult();
        }

        /// <summary>
        /// Предоставляет данные из диалога в виде модели данных
        /// </summary>
        /// <returns>Модель данных <see cref="Mission"/></returns>
        private ICollection<IRowItem> GetModelDate()
        {
            IEnumerable<IRowItem> decriptions = Descriptions.Select(x => x.Model);

            return new Collection<IRowItem>(decriptions.ToList());
        }

        /// <summary>
        /// Обработка события изменения выбранной строки
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Rows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bindings.Update();
        }

        #endregion Private Methods
    }
}
