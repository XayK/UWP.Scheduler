﻿using SchedulingApp.CalendarVisualizer.Controls;
using SchedulingApp.CalendarVisualizer.Helpers;
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

        #region Private Properties

        /// <summary>
        /// Представляет или задает дату конца месяца
        /// </summary>
        private DateTime EndMonth => DrawData.EndMonth;

        /// <summary>
        /// Представляет высоту холста
        /// </summary>
        private double Height => _canvasManipulation.ActualHeight;

        /// <summary>
        /// Представляет высоту элемента на холсте
        /// </summary>
        private double HeightStep => Height / DrawData.WeeksInMonth;

        /// <summary>
        /// Представляет или задает дату начала месяца
        /// </summary>
        private DateTime StartMonth => DrawData.StartMonth;
        /// <summary>
        /// Представляет ширину холста
        /// </summary>
        private double Width => _canvasManipulation.ActualWidth;
        /// <summary>
        /// Представляет ширирну элемента на холсте
        /// </summary>
        private double WidthStep => Width / DrawData.DaysInWeek;

        #endregion Private Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="ObjectsVisualizers"/>
        /// </summary>
        /// <param name="canvasManipulation">Контрол, для визуализиции элементов календаря</param>
        public ObjectsVisualizers(Canvas canvasManipulation)
        {
            _canvasManipulation = canvasManipulation;

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
            int startDayOfWeek = DayOfWeekHelper.GrigorianDayOfWeek(startVisualize);
            int weeksPassed = SetWeekPassed(startVisualize);           

            double left = WidthStep * startDayOfWeek;
            double top = HeightStep * weeksPassed;

            Canvas.SetLeft(visualizeControl, left);
            Canvas.SetTop(visualizeControl, top);

            SetEndVisualizationTime(out DateTime endVisualize);
            double hourLength = WidthStep / DrawData.HoursInDay;

            visualizeControl.Width = (endVisualize - startVisualize).TotalHours * hourLength;
            visualizeControl.Height = HeightStep;

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

            int SetWeekPassed(DateTime startVisualize)
            {
                int weeksPassed = 0;

                for (DateTime day = StartMonth; day< startVisualize; day+= TimeSpan.FromDays(1))
                {
                    if (day.DayOfWeek == DrawData.EndOfWeek)
                    {
                        weeksPassed++;
                    }
                }

                return weeksPassed;
            }

            void SetEndVisualizationTime(out DateTime endVisualize)
            {
                endVisualize = presenter.EndDateTime;
                DateTime endOfCurrentWeek = startVisualize.Date + TimeSpan.FromDays
                    (DrawData.DaysInWeek - DayOfWeekHelper.GrigorianDayOfWeek(startVisualize));
                //endOfCurrentWeek += TimeSpan.FromDays(1);

                if (endVisualize > endOfCurrentWeek)
                {
                    endVisualize = endOfCurrentWeek;
                    SetPossition(visualizeControl, endVisualize + TimeSpan.FromMinutes(1));
                }
            }

            // #endregion SetPosition Functions
        }

        #endregion Private Methods
    }
}
