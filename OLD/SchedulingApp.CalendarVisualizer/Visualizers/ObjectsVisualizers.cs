using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SchedulingApp.CalendarVisualizer.Visualizers
{
    /// <summary>
    /// Представляет функционал для визуализации и манипуляции объектов контрола расписания календаря
    /// </summary>
    internal class ObjectsVisualizers
    {
        #region Private Fields

        /// <summary>
        /// Представляет холст, оперирующий визуализацией элементов
        /// </summary>
        private Canvas _canvasManipulation;

        /// <summary>
        /// Представляет или задает дату конца месяца
        /// </summary>
        
        private DateTime _endMonth;

        /// <summary>
        /// Представляет или задает дату начала месяца
        /// </summary>
        private DateTime _startMonth;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="ObjectsVisualizers"/>
        /// </summary>
        /// <param name="canvasManipulation">Контрол, для визуализиции элементов календаря</param>
        public ObjectsVisualizers(Canvas canvasManipulation)
        {
            _canvasManipulation = canvasManipulation;

            _canvasManipulation.SizeChanged += CanvasManipulation_SizeChanged;
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Загрузка задачи на визулизацию холста
        /// </summary>
        private void InsertMission()
        {

        }

        /// <summary>
        /// Удаления задачи с холста
        /// </summary>
        private void RemoveMission()
        {

        }

        /// <summary>
        /// Обработка события изменения размеров холста
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void CanvasManipulation_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        #endregion Private Methods

    }
}
