using SchedulingApp.Abstraction;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SchedulingApp.Services.Context
{
    /// <summary>
    /// Представляет контекст для работы с фреймом, содержащий страницу
    /// </summary>
    internal class FrameContext
    {
        /// <summary>
        /// Предоставляет глубину навигации назад
        /// </summary>
        public int FrameBackDepth => _frame.BackStack.Count;

        /// <summary>
        /// Предоставляет глубину навигации вперед
        /// </summary>
        public int FrameForwardDepth => _frame.ForwardStack.Count;

        /// <summary>
        /// Предоставляет фрейм, отображающий страницу,
        /// а также выполняющий роль навигатора
        /// </summary>
        private readonly Frame _frame;

        /// <summary>
        /// Инициализирует экземляр <see cref="FrameContext"/>
        /// </summary>
        /// <param name="frame"></param>
        public FrameContext(Frame frame)
        {
            _frame = frame;
            _frame.Navigated += Frame_Navigated;
        }

        /// <summary>
        /// Уничтожает <see cref="FrameContext"/>
        /// </summary>
        ~FrameContext()
        {
            _frame.Navigated -= Frame_Navigated;
        }

        /// <summary>
        /// Обработывает события навигации фрейма на новую страницу
        /// </summary>
        /// <param name="sender">Инициатор события</param>
        /// <param name="e">Параметр</param>
        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            ///TODO: правильная привязка?
            var page = _frame.Content as IPageView;
            var pageElement = page as FrameworkElement;

            pageElement.DataContext = page.ViewModel;
        }

        /// <summary>
        /// Осуществляет навигацию на необходимую страницу
        /// </summary>
        /// <param name="pageType">Тип страницы</param>
        public void Navigate(Type pageType)
        {
            if (pageType == null)
            { return; }
        
            _frame.Navigate(pageType);
        }

        /// <summary>
        /// Осуществляет навигацию на предидущую страницу
        /// </summary>
        public void NavigateBack()
        {
            if (FrameBackDepth == 0)
            { return; }
        
            _frame.GoBack();
        }

        /// <summary>
        /// Осуществляет навигацию на страницу вперед
        /// </summary>
        public void NavigateForward()
        {
            if (FrameForwardDepth == 0)
            { return; }
        
            _frame.GoForward();
        }
    }
}
