using SchedulingApp.Data.Models.Abstraction;
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
        public RowItemViewModel()
        {

        }

        /// <summary> <inheritdoc/> </summary>
        public override IRowItem Model => throw new System.NotImplementedException();
    }
}
