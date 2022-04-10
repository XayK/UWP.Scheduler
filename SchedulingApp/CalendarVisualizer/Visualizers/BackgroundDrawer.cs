using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Toolkit.Uwp.Helpers;
using SchedulingApp.CalendarVisualizer.Helpers;
using System;
using System.Numerics;
using Windows.UI.Xaml;

namespace SchedulingApp.CalendarVisualizer.Visualizers
{
    /// <summary>
    /// Представляет функционал отрисоки фона календаря
    /// </summary>
    internal class BackgroundDrawer
    {
        #region Private Fields

        /// <summary>
        /// Представляет контанту ширины линий сетки
        /// </summary>
        private const int STROKE_GRID = 4;

        /// <summary>
        /// Представляет константу отрисовки цвета линий разграничения дня
        /// </summary>
        private const string LINE_COLOR = "#BB7070";

        /// <summary>
        /// Представляет контрол холста, визуализующий фон элементов расписания
        /// </summary>
        private readonly CanvasControl _canvasBackground;

        #endregion Private Fields

        #region Private Properties

        /// <summary>
        /// Представляет или задает дату конца месяца
        /// </summary>
        private DateTime EndMonth => DrawData.EndMonth;

        /// <summary>
        /// Представляет высоту холста
        /// </summary>
        private double Height => _canvasBackground.ActualHeight;

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
        private double Width => _canvasBackground.ActualWidth;
        /// <summary>
        /// Представляет ширирну элемента на холсте
        /// </summary>
        private double WidthStep => Width / DrawData.DaysInWeek;

        #endregion Private Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="BackgroundDrawer"/>
        /// </summary>
        /// <param name="canvasBackground">Контрол отрисовки фона календяря</param>
        public BackgroundDrawer(CanvasControl canvasBackground)
        {
            _canvasBackground = canvasBackground;

            _canvasBackground.SizeChanged += CanvasBackground_SizeChanged;
            _canvasBackground.Draw += CanvasBackground_Draw;
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Отрисовка фона
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="args">Параметр</param>
        private void CanvasBackground_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            float heightStep = (float)HeightStep;
            float widthStep = (float)WidthStep;

            int weekCounter = 0;

            for(DateTime dayMonth = StartMonth; dayMonth <= EndMonth; dayMonth += TimeSpan.FromDays(1))
            {
                int dayInWeek = DayOfWeekHelper.GrigorianDayOfWeek(dayMonth);

                float topHeigth = weekCounter * heightStep;
                float bottomHeigth = (weekCounter + 1) * heightStep;
                float leftWidth = dayInWeek * widthStep;
                float rightWidth = (dayInWeek + 1) * widthStep;

                Vector2 leftTopPoint = new(leftWidth, topHeigth);
                Vector2 leftBottomPoint = new(leftWidth, bottomHeigth);
                Vector2 rightTopPoint = new(rightWidth, topHeigth);
                Vector2 rightBottomPoint = new(rightWidth, bottomHeigth);

                args.DrawingSession.DrawLine(leftTopPoint, rightTopPoint, ColorHelper.ToColor(LINE_COLOR), STROKE_GRID);
                args.DrawingSession.DrawLine(leftBottomPoint, leftTopPoint, ColorHelper.ToColor(LINE_COLOR), STROKE_GRID);
                args.DrawingSession.DrawLine(leftBottomPoint, rightBottomPoint, ColorHelper.ToColor(LINE_COLOR), STROKE_GRID);
                args.DrawingSession.DrawLine(rightTopPoint, rightBottomPoint, ColorHelper.ToColor(LINE_COLOR), STROKE_GRID);

                args.DrawingSession.DrawText(dayMonth.Date.Day.ToString(),leftTopPoint, ColorHelper.ToColor(LINE_COLOR));

                if(dayMonth.DayOfWeek == DrawData.EndOfWeek)
                {
                    weekCounter++;
                }
            }
        }     

        /// <summary>
        /// Обработка события изменения размеров холста
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void CanvasBackground_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        #endregion Private Methods

    }
}
