using SchedulingApp.Presenter.Entities.Abstraction;
using SchedulingApp.Presenter.Entities.RowItems.Base;
using SchedulingApp.Data.Models.Elements;
using SchedulingApp.Data.Models.Abstraction;

namespace SchedulingApp.Presenter.Entities.RowItems
{
    /// <summary>
    /// Представляет данные, для отображения строки описания задачи
    /// </summary>
    internal class RowItemViewModel : BaseRowItemViewModel
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="RowItemViewModel"/>
        /// </summary>
        public RowItemViewModel()
        {

        }

        /// <summary> <inheritdoc/> </summary>
        public override IRowItem Model => throw new System.NotImplementedException();
    }
}
