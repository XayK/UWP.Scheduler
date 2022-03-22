using LiteDB;
using System;
using System.IO;
using Windows.Storage;

namespace SchedulingApp.Data.Context
{
    /// <summary>
    /// Предоставляет контекст доступа к базе данных
    /// </summary>
    internal class DatabaseContext : IDisposable
    {
        #region Private Fields

        /// <summary>
        /// Предоставляет константу имени базы данных
        /// </summary>
        private const string DATABASE_FILENAME = "app_task.db";

        /// <summary>
        /// Предоставляет подключения к базе данных
        /// </summary>
        private readonly LiteDatabase _connection;

        #endregion Private Fields

        /// <summary>
        /// Предоставляет доступ к контексту базы данных
        /// </summary>
        public LiteDatabase Database => _connection;

        #region Private Properties

        /// <summary>
        /// Предоставляет строку подключения
        /// </summary>
        private ConnectionString ConnectionString => GetDatabasePath();

        /// <summary>
        /// Предоставляте настройки базы данных
        /// </summary>
        private BsonMapper DatabaseMapper => GetDatabaseSettings();

        #endregion Private Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="DatabaseContext"/>
        /// </summary>
        public DatabaseContext()
        {
            _connection = new LiteDatabase(ConnectionString, DatabaseMapper);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Обработка ликвидации подключения к базе данных
        /// </summary>
        public void Dispose()
        {
            _connection.Dispose();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Создает строку подключения к базе данных
        /// </summary>
        /// <returns>Возвращает строку подключения <see cref="ConnectionString"/></returns>
        private ConnectionString GetDatabasePath()
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, DATABASE_FILENAME);
            return new ConnectionString(path);
        }

        /// <summary>
        /// Создает настроку базы данных
        /// </summary>
        /// <returns>Возвращает маппер с настройками <see cref="BsonMapper"/></returns>
        private BsonMapper GetDatabaseSettings()
        {
            BsonMapper mapper = new BsonMapper()
            {
                EmptyStringToNull = false
            };
            return mapper;
        }

        #endregion Private Methods
    }
}
