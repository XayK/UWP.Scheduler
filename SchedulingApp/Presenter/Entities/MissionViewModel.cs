using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Presenter.Entities.Base;

namespace SchedulingApp.Presenter.Entities
{
    /// <summary>
    /// Предоставляет данные, для отображения задачи
    /// </summary>
    internal class MissionViewModel : BaseMissionViewModel
    {
        /// <summary>
        /// Инициализирует экземлпяр <see cref="MissionViewModel"/>
        /// </summary>
        public MissionViewModel()
        {
        }

        /// <summary> <inheritdoc/> </summary>
        public override IMission Model => throw new System.NotImplementedException();
    }
}
