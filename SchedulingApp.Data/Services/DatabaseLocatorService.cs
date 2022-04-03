using SchedulingApp.Data.Storages;
using System;

namespace SchedulingApp.Data.Services
{
    /// <summary>
    /// Предоставляет сервис для работы с базой данных приложения
    /// Содержит: Хранилище задач,
    ///           ???
    /// </summary>
    public class DatabaseLocatorService
    {
        #region Private Fields

        /// <summary>
        /// Представляет реализацию синглтона  
        /// </summary>
        private static readonly Lazy<DatabaseLocatorService> _instance =
            new Lazy<DatabaseLocatorService>(() => new DatabaseLocatorService());

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Предоставляет доступ к экземпляру <see cref="DatabaseLocatorService"/>
        /// </summary>
        public static DatabaseLocatorService Instance => _instance.Value;

        /// <summary>
        /// Предоставляет доступ к хранилищу задач
        /// </summary>
        public MissionStorage MissionsStorage { get; }

        #endregion Public Properties

        #region Private Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="DatabaseLocatorService"/>
        /// </summary>
        private DatabaseLocatorService()
        {
            MissionsStorage = new MissionStorage();
        }

        #endregion Private Constructors

    }
}
