using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Toolkit.Uwp.Helpers;
using SchedulingApp.CalendarVisualizer.Helpers;
using System;
using System.Numerics;
using Windows.Foundation;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace SchedulingApp.CalendarVisualizer.Visualizers
{
    /// <summary>
    /// Представляет функционал отрисоки фона календаря
    /// </summary>
    internal class BackgroundDrawer
    {
        #region Private Fields

        /// <summary>
        /// Представляет константу отрисовки цвета линий разграничения дня
        /// </summary>
        private readonly static string LINE_COLOR = Application.Current.Resources["SystemAccentColor"].ToString();

        /// <summary>
        /// Представляет константу отрисовки цвета недели, при нахождения на ней урока
        /// </summary>
        private const string POINTER_HOVER = "#30909090";

        /// <summary>
        /// Представляет константу цвета текста
        /// </summary>
        private const string TEXT_FOREGROUND = "#3D3D3D";

        /// <summary>
        /// Представляет контанту ширины линий сетки
        /// </summary>
        private const int STROKE_GRID = 3;
        /// <summary>
        /// Представляет контрол холста, визуализующий фон элементов расписания
        /// </summary>
        private readonly CanvasControl _canvasBackground;

        /// <summary>
        /// Представляет данные о датах, необходмые для отрисовки таймлайна
        /// </summary>
        private readonly DrawData _drawData;

        /// <summary>
        /// Представляет или задает последную отмеченную неделю.
        /// При -1 не отображается
        /// </summary>
        private int _selectedWeek;

        #endregion Private Fields

        #region Private Properties

        /// <summary>
        /// Представляет или задает дату конца месяца
        /// </summary>
        private DateTime EndMonth => _drawData.EndMonth;

        /// <summary>
        /// Представляет высоту холста
        /// </summary>
        private double Height => _canvasBackground.ActualHeight;

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
        private double Width => _canvasBackground.ActualWidth;
        /// <summary>
        /// Представляет ширирну элемента на холсте
        /// </summary>
        private double WidthStep => Width / DayOfWeekHelper.DaysInWeek;

        #endregion Private Properties

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="BackgroundDrawer"/>
        /// </summary>
        /// <param name="canvasBackground">Контрол отрисовки фона календяря</param>
        /// <param name="drawData">Данные о датах для отрисовки</param>
        public BackgroundDrawer(CanvasControl canvasBackground, DrawData drawData)
        {
            _canvasBackground = canvasBackground;
            _drawData = drawData;
            _selectedWeek = -1;

            _canvasBackground.Draw += CanvasBackground_Draw;
            _canvasBackground.PointerMoved += CanvasBackground_PointerMoved;
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Обработка перемещния указателя на холсте
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="args">Параметр</param>
        private void CanvasBackground_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint pointer = e.GetCurrentPoint(_canvasBackground);
            _selectedWeek = (int)(pointer.Position.Y / HeightStep);
            _canvasBackground.Invalidate();
        }

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

            if(_selectedWeek > -1)
            {
                float x = 0;
                float width = (float)Width;
                float y = (float)(_selectedWeek * HeightStep);
                float height = (float)HeightStep;

                args.DrawingSession.FillRectangle(x,y,width,height, ColorHelper.ToColor(POINTER_HOVER));
            }

            for (DateTime dayMonth = StartMonth; dayMonth <= EndMonth; dayMonth += TimeSpan.FromDays(1))
            {
                int dayInWeek = DayOfWeekHelper.GrigorianDayOfWeek(dayMonth);

                float topHeigth = weekCounter * heightStep;
                float bottomHeigth = (weekCounter + 1) * heightStep;
                float leftWidth = dayInWeek * widthStep;
                float rightWidth = (dayInWeek + 1) * widthStep;

                Rect rectanlge = new(leftWidth + 5, topHeigth + 5, widthStep - 5, heightStep - 5);
                //Vector2 leftTopPoint = new(, );
                //Vector2 leftBottomPoint = new(leftWidth + 2, bottomHeigth -2);
                //Vector2 rightTopPoint = new(rightWidth - 2, topHeigth + 2);
                //Vector2 rightBottomPoint = new(rightWidth - 2, bottomHeigth - 2);

                args.DrawingSession.DrawRoundedRectangle(rectanlge, 5, 5, ColorHelper.ToColor(LINE_COLOR), STROKE_GRID);
                //args.DrawingSession.DrawLine(leftTopPoint, rightTopPoint, ColorHelper.ToColor(LINE_COLOR), STROKE_GRID);
                //args.DrawingSession.DrawLine(leftBottomPoint, leftTopPoint, ColorHelper.ToColor(LINE_COLOR), STROKE_GRID);
                //args.DrawingSession.DrawLine(leftBottomPoint, rightBottomPoint, ColorHelper.ToColor(LINE_COLOR), STROKE_GRID);
                //args.DrawingSession.DrawLine(rightTopPoint, rightBottomPoint, );

                Vector2 textDatePoint = new(leftWidth  + 8, topHeigth + 8);
                
                args.DrawingSession.DrawText(dayMonth.Date.Day.ToString(), textDatePoint, ColorHelper.ToColor(TEXT_FOREGROUND));

                if (dayMonth.DayOfWeek == DayOfWeekHelper.EndOfWeek)
                {
                    weekCounter++;
                }
            }
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// Вызов форсированной переотрисовки фона
        /// </summary>
        public void ForceRedraw()
        {
            _canvasBackground.Invalidate();
        }

        #endregion Public Methods
    }
}
