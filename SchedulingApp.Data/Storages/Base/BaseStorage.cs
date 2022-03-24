using LiteDB;
using SchedulingApp.Data.Context;
using SchedulingApp.Data.Models.Abstraction;
using System.Collections.Generic;

namespace SchedulingApp.Data.Storages.Base
{
    /// <summary>
    /// Представляет базовый класс для хранилища данных
    /// </summary>
    public abstract class BaseStorage
    {
        /// <summary>
        /// Получает все элементы коллекции
        /// </summary>
        /// <returns>Перечисления всех элементов коллекции</returns>
        protected IEnumerable<T> GetAll<T>() where T : IIdentifier
        {
            using var db = new DatabaseContext();
            return db.Database.GetCollection<T>().FindAll();
        }

        /// <summary>
        /// Получает элемент коллекции по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Элемент коллекции</returns>
        protected T GetById<T>(string id) where T : IIdentifier
        {
            using var db = new DatabaseContext();
            return db.Database.GetCollection<T>().FindById(id);
        }

        /// <summary>
        /// Добавляет новый элемент в коллекцию
        /// </summary>
        /// <param name="model">Модель данных объекта</param>
        protected void Insert<T>(T model) where T : IIdentifier
        {
            using var db = new DatabaseContext();
            db.Database.BeginTrans();
            db.Database.GetCollection<T>().Insert(model);
            db.Database.Commit();
        }

        /// <summary>
        /// Обновляет существующий элемент в коллекции
        /// </summary>
        /// <param name="model">Модель данных объекта</param>
        protected void Update<T>(T model) where T : IIdentifier
        {
            using var db = new DatabaseContext();
            db.Database.BeginTrans();
            db.Database.GetCollection<T>().Update(model);
            db.Database.Commit();
        }

        /// <summary>
        /// Удаляет элемент из коллекции
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        protected void Remove<T>(string id) where T : IIdentifier
        {
            using var db = new DatabaseContext();
            db.Database.BeginTrans();
            db.Database.GetCollection<T>().Delete(id);
            db.Database.Commit();
        }
    } 
}
