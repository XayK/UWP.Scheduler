using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Data.Models.Elements;
using SchedulingApp.Presenter.Entities.Elements.Base;

namespace SchedulingApp.Presenter.Entities.Elements
{
    /// <summary>
    /// Представляет данные, для отображения строки описания задачи
    /// </summary>
    internal class RowItemViewModel : BaseRowItemViewModel
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="RowItemViewModel"/>
        /// </summary>
        /// <param name="rowItem">Модель данных</param>
        public RowItemViewModel(RowItem rowItem) : base(rowItem)
        {
        }

        /// <summary> <inheritdoc/> </summary>
        public override IRowItem Model => throw new System.NotImplementedException();
    }
}
