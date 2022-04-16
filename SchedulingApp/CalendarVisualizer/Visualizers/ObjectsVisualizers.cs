using SchedulingApp.CalendarVisualizer.Helpers;
using SchedulingApp.Controls;
using SchedulingApp.Presenter.Entities.Abstraction;
using SchedulingApp.Presenter.Pages;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
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
        private readonly Canvas _canvasManipulation;

        /// <summary>
        /// Предоставляет данные для отрисовки
        /// </summary>
        private readonly DrawData _drawData;

        #endregion Private Fields

        #region Private Properties

        /// <summary>
        /// Представляет или задает дату конца месяца
        /// </summary>
        private DateTime EndMonth => _drawData.EndMonth;

        /// <summary>
        /// Представляет высоту холста
        /// </summary>
        private double Height => _canvasManipulation.ActualHeight;

        /// <summary>
        /// Представляет высоту элемента на холсте
        /// </summary>
        private double HeightStep => Height / _drawData.WeeksInMonth;

        /// <summary>
        /// Представляет или задает дату начала месяца
        /// </summary>
        private DateTime StartMonth => _drawData.StartMonth;
        /// <summary>
        /// Представляет ширину холста
        /// </summary>
        private double Width => _canvasManipulation.ActualWidth;
        /// <summary>
        /// Представляет ширирну элемента на холсте
        /// </summary>
        private double WidthStep => Width / DayOfWeekHelper.DaysInWeek;

        #endregion Private Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="ObjectsVisualizers"/>
        /// </summary>
        /// <param name="canvasManipulation">Контрол, для визуализиции элементов календаря</param>
        /// <param name="drawData">Данные о датах для отрисовки</param>
        public ObjectsVisualizers(Canvas canvasManipulation, DrawData drawData)
        {
            _canvasManipulation = canvasManipulation;
            _drawData = drawData;

            _canvasManipulation.SizeChanged += CanvasManipulation_SizeChanged;
            CalendarPageViewModel.Instance.Missions.CollectionChanged += Missions_CollectionChanged;
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Обработка события изменения размеров холста
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void CanvasManipulation_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (var control in _canvasManipulation.Children)
            {
                MissionTimelineControl missionControl = control as MissionTimelineControl;
                UpdateMissionPosition(missionControl);
            }
        }

        /// <summary>
        /// Удаляет дубликаты контрола задачи, имеющих одинаковые DataContext
        /// </summary>
        /// <param name="control">Контрол задачи</param>
        private void DeleteMissionDoubles(MissionTimelineControl control)
        {
            IEnumerable<UIElement> items = _canvasManipulation.Children.Where
                (mission => (mission as MissionTimelineControl).DataContext == control.DataContext);

            foreach (var item in items)
            {
                MissionTimelineControl itemControl = item as MissionTimelineControl;
                if (item != control)
                {
                    _canvasManipulation.Children.Remove(item);
                }
            }
        }

        /// <summary>
        /// Загрузка задачи на визулизацию холста
        /// </summary>
        /// <param name="mission">Презентер данных задачи</param>
        private void InsertMissionToCanvas(IMissionViewModel mission)
        {
            MissionTimelineControl control = new(mission);
            _canvasManipulation.Children.Add(control);
            SetPossition(control);
        }

        /// <summary>
        /// Обработка события изменения задачи
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Missions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (IMissionViewModel item in e.NewItems)
                    {
                        InsertMissionToCanvas(item);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (IMissionViewModel item in e.OldItems)
                    {
                        RemoveMissionFromCanvas(item);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _canvasManipulation.Children.Clear();
                    break;
            }
        }

        /// <summary>
        /// Удаления задачи с холста
        /// </summary>
        /// <param name="mission">Презентер данных задачи</param>
        private void RemoveMissionFromCanvas(IMissionViewModel mission)
        {
            IEnumerable<UIElement> toRemove =
                _canvasManipulation.Children.Where
                (obj => (obj as MissionTimelineControl).DataContext == mission);

            foreach (var item in toRemove)
            {
                MissionTimelineControl itemControl = item as MissionTimelineControl;
                _canvasManipulation.Children.Remove(itemControl);
            }
        }

        /// <summary>
        /// Задатие позиции задачи в визуализаторе
        /// </summary>
        /// <param name="control">Контрол для задатия визуализации</param>
        /// <param name="startVisualize">Дата начала визуализации</param>
        private void SetPossition(MissionTimelineControl control, DateTime? startVisualizeDate = null)
        {
            if (startVisualizeDate == null)
            {
                DeleteMissionDoubles(control);
            }

            IMissionViewModel presenter = control.DataContext as IMissionViewModel;
            bool isIntersects = presenter.StartDateTime <= EndMonth || presenter.EndDateTime >= StartMonth;

            if (isIntersects == false)
            {
                return;
            }

            SetVisualizeControl(out MissionTimelineControl visualizeControl);
            SetStartVisualizationTime(out DateTime startVisualize);
            SetEndVisualizationTime(out DateTime endVisualize);

            visualizeControl.StartDate = startVisualize;
            visualizeControl.EndDate = endVisualize;
            visualizeControl.OffsetPosition = visualizeControl.NeigthboorsCounter = GetNeigthboorCounter(visualizeControl);

            UpdateMissionPosition(visualizeControl);

            // #region SetPosition Functions
            void SetVisualizeControl(out MissionTimelineControl visualizeControl)
            {
                if (startVisualizeDate != null)
                {
                    visualizeControl = new MissionTimelineControl(control.DataContext);
                    _canvasManipulation.Children.Add(visualizeControl);
                }
                else
                {
                    visualizeControl = control;
                }
            }

            void SetStartVisualizationTime(out DateTime startVisualize)
            {
                if (startVisualizeDate == null)
                {
                    startVisualize = presenter.StartDateTime;
                    if (startVisualize < StartMonth)
                    {
                        startVisualize = StartMonth;
                    }
                }
                else
                {
                    startVisualize = (DateTime)startVisualizeDate;
                }
            }

            void SetEndVisualizationTime(out DateTime endVisualize)
            {
                endVisualize = presenter.EndDateTime;
                DateTime endOfCurrentWeek = startVisualize.Date + DayOfWeekHelper.LeftToEndOfWeek(startVisualize);

                if (endVisualize > endOfCurrentWeek)
                {
                    endVisualize = endOfCurrentWeek;
                    SetPossition(visualizeControl, endVisualize + TimeSpan.FromMinutes(1));
                }
            }
            // #endregion SetPosition Functions
        }

        /// <summary>
        /// Обновление позиции контрола
        /// </summary>
        /// <param name="control">Контрол задачи</param>
        private void UpdateMissionPosition(MissionTimelineControl control)
        {
            int startDayOfWeek = DayOfWeekHelper.GrigorianDayOfWeek(control.StartDate);
            int weeksPassed = DayOfWeekHelper.GetWeekPassedOnMonth(control.StartDate);

            double offsetTop = control.OffsetPosition == 0 ? 0 : (HeightStep / (double)(control.NeigthboorsCounter + 1));

            double left = WidthStep * startDayOfWeek;
            double top = HeightStep * weeksPassed + offsetTop;

            Canvas.SetLeft(control, left);
            Canvas.SetTop(control, top);

            double hourLength = WidthStep / _drawData.HoursInDay;

            control.Width = (control.EndDate - control.StartDate).TotalHours * hourLength;
            control.Height = control.NeigthboorsCounter == 0 ? HeightStep : (HeightStep / (double)(control.NeigthboorsCounter + 1));
        }

        /// <summary>
        /// Вычисляет кол-во пересечений у одной задачи с другими
        /// </summary>
        /// <param name="currentMission">Контрол задачи</param>
        /// <returns>Кол-во пересечений/соседей</returns>
        private int GetNeigthboorCounter(MissionTimelineControl currentMission)
        {
            List<MissionTimelineControl> missions = _canvasManipulation.Children.Select
                (mission => mission as MissionTimelineControl)
                .ToList();

            int counter = 0;

            foreach (MissionTimelineControl mission in missions)
            {
                if (mission == currentMission)
                {
                    continue;
                }

                bool isEndDateIntersects = mission.EndDate <= currentMission.EndDate && mission.EndDate >= currentMission.StartDate;
                bool isStartDateIntersects = mission.StartDate <= currentMission.EndDate && mission.StartDate >= currentMission.StartDate;
                bool isPresenterInMission = mission.StartDate <= currentMission.StartDate && mission.EndDate >= currentMission.EndDate;

                if (isEndDateIntersects || isStartDateIntersects || isPresenterInMission)
                {
                    counter++;
                    mission.NeigthboorsCounter++;
                    UpdateMissionPosition(mission);
                }
            }

            return counter;
        }

        #endregion Private Methods
    }
}
