using SchedulingApp.Data.Models;
using SchedulingApp.Data.Storages.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchedulingApp.Data.Storages
{
    /// <summary>
    /// Представляет хранилище данных о задачах,
    /// используемых при состоавлении расписания
    /// </summary>
    public class MissionStorage : BaseStorage
    {
        /// <summary>
        /// Получить все задачи из расписания
        /// </summary>
        /// <returns>Возвращает перечисление всех задач</returns>
        public IEnumerable<Mission> GetAll()
        {
            return base.GetAll<Mission>();
        }

        /// <summary>
        /// Получить задачи на заданный месяц
        /// </summary>
        /// <param name="date">Дата, указывающая на конкреттный месяц</param>
        /// <returns>Возвращает перечисление, указанных в текущем месяце</returns>
        public IEnumerable<Mission> GetForMonth(DateTime date)
        {
            DateTime firstMonthDate = new DateTime(date.Year, date.Month, 1);
            DateTime lastMonthDate = new DateTime(date.Year, date.Month, 1);
            lastMonthDate = lastMonthDate.AddMonths(1);
            lastMonthDate = lastMonthDate.AddDays(-1);


            IEnumerable<Mission> neededCollection = GetAll<Mission>();
            return neededCollection.Where(x =>
                (x.EndDateTime.Date < firstMonthDate == false)
                &&
                (x.StartDateTime.Date > firstMonthDate == false)
            );
        }

        /// <summary>
        /// Добавление в коллекцию новой задачи
        /// </summary>
        /// <param name="model">Модель данных задачи</param>
        public void Insert(Mission model)
        {
            base.Insert<Mission>(model);
        }

        /// <summary>
        /// Обновление данных задачи в коллекции
        /// </summary>
        /// <param name="model">Модель данных задачи</param>
        public void Update(Mission model)
        {
            base.Update<Mission>(model);
        }

        /// <summary>
        /// Удаление задачи из коллекции
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        public void Remove(string id)
        {
            base.Remove<Mission>(id);
        }
    }
}
