using SchedulingApp.Data.Models;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Presenter.Entities.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchedulingApp.Presenter.Entities
{
    /// <summary>
    /// Предоставляет данные, для отображения задачи
    /// </summary>
    internal class MissionViewModel : BaseMissionViewModel
    {
        #region Public Properties

        /// <summary> <inheritdoc/> </summary>
        public override IMission Model => GetModelData();

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземлпяр <see cref="MissionViewModel"/>
        /// </summary>
        /// <param name="mission">Модель данных</param>
        public MissionViewModel(Mission mission) : base(mission)
        {
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Возврщает модель данных
        /// </summary>
        /// <returns>Возвращает <see cref="IMission"/></returns>
        private IMission GetModelData()
        {
            IMission model = new Mission()
            {
                StartDateTime = StartDateTime,
                EndDateTime = EndDateTime,
                IsImportant = IsImportant,
                Id = _id,
                Title = Title
            };

            IEnumerable<IRowItem> descriptions = Descriptions.Select(x => x.Model);

            model.Descriptions = new Collection<IRowItem>(descriptions.ToList());

            return model;
        }

        #endregion Private Methods
    }
}
