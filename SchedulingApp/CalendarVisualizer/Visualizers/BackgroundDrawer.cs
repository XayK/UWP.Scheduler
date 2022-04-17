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
        /// Представляет константу отрисовки цвета недели, при нахождения на ней урока
        /// </summary>
        private const string POINTER_HOVER = "#30909090";

        /// <summary>
        /// Представляет константу цвета текста
        /// </summary>
        private const string TEXT_FOREGROUND = "#3D3D3D";

        /// <summary>
        /// Представляет константу отрисовки цвета линий разграничения дня
        /// </summary>
        private static readonly string ACCENT_COLOR = GetAccentTransparencyColor("SystemAccentColor");

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
            _canvasBackground.PointerExited += CanvasBackground_PointerExited;
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

            for (DateTime dayMonth = StartMonth; dayMonth <= EndMonth; dayMonth += TimeSpan.FromDays(1))
            {
                int dayInWeek = DayOfWeekHelper.GrigorianDayOfWeek(dayMonth);

                float topHeigth = weekCounter * heightStep;
                float leftWidth = dayInWeek * widthStep;

                Rect rectanlge = new(leftWidth + 5, topHeigth + 5, widthStep - 10, heightStep - 10);

                string fillColor = weekCounter == _selectedWeek ? GetAccentTransparencyColor("SystemAccentColorDark2") : ACCENT_COLOR;

                args.DrawingSession.FillRoundedRectangle(rectanlge, 5, 5, ColorHelper.ToColor(fillColor));

                Vector2 textDatePoint = new(leftWidth + 12, topHeigth + 8);

                args.DrawingSession.DrawText(dayMonth.Date.Day.ToString(), textDatePoint, ColorHelper.ToColor(TEXT_FOREGROUND));

                if (dayMonth.DayOfWeek == DayOfWeekHelper.EndOfWeek)
                {
                    weekCounter++;
                }
            }

            //if (_selectedWeek > -1)
            //{
            //    float x = 0;
            //    float width = (float)Width;
            //    float y = (float)(_selectedWeek * HeightStep);
            //    float height = (float)HeightStep;

            //    args.DrawingSession.FillRectangle(x, y, width, height, ColorHelper.ToColor(POINTER_HOVER));
            //}
        }

        /// <summary>
        /// Обработка перемещния указателя за пределы холста
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void CanvasBackground_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            _selectedWeek = -1;
            _canvasBackground.Invalidate();
        }

        /// <summary>
        /// Обработка перемещния указателя на холсте
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void CanvasBackground_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint pointer = e.GetCurrentPoint(_canvasBackground);
            _selectedWeek = (int)(pointer.Position.Y / HeightStep);
            _canvasBackground.Invalidate();
        }

        /// <summary>
        /// Получает полупрозрачный цвет Accent
        /// </summary>
        /// <param name="resourceKey">Ключ рерурса цвета accent</param>
        /// <returns>Возвращает hex цвета</returns>
        private static string GetAccentTransparencyColor(string resourceKey)
        {
            string accent;

            try
            {
                accent = Application.Current.Resources[resourceKey].ToString();
            }
            catch
            {
                ///Базовый цвет в случае ошибки
                return "#000";
            }

            string transparency = "60";

            int hexWithAlphaLength = 9;
            int fullHexLength = 7;

            if (accent.Length == hexWithAlphaLength)
            {
                accent = string.Format("#{0}{1}", transparency, accent.Substring(3));
            }

            if (accent.Length == fullHexLength)
            {
                accent = string.Format("#{0}{1}", transparency, accent.Substring(1));
            }

            return accent;
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
