using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Data.Models.Elements;
using SchedulingApp.Presenter.Entities.Elements.Base;

namespace SchedulingApp.Presenter.Entities.Elements
{
    /// <summary>
    /// Представляет данные, для отображения строки описания задачи
    /// </summary>
    public class RowItemViewModel : BaseRowItemViewModel
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="RowItemViewModel"/>
        /// </summary>
        /// <param name="rowItem">Модель данных</param>
        public RowItemViewModel(RowItem rowItem) : base(rowItem)
        {
        }

        /// <summary> <inheritdoc/> </summary>
        public override IRowItem Model => GetModelData();


        /// <summary>
        /// Возврщает модель данных
        /// </summary>
        /// <returns>Возвращает <see cref="IRowItem"/></returns>
        private IRowItem GetModelData()
        {
            IRowItem model = new RowItem()
            {
                IsCheckable = IsCheckEnabled,
                IsChecked = IsChecked,
                Text = Text
            };

            return model;
        }
    }
}
