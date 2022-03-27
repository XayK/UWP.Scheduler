namespace SchedulingApp.Presenter.Entities.Abstraction
{
    /// <summary>
    /// Интерфейс, реализующий ViewModel для сущностей, хранимых в БД
    /// </summary>
    /// <typeparam name="T">Соотвествующая представлению модель данных</typeparam>
    internal interface IEntityViewModel<T>
    {
        /// <summary>
        /// Предоставляет модель данных <see cref="T"/>
        /// </summary>
        public T Model { get; }
    }
}
