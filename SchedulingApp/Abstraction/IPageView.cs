using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp.Abstraction
{
    /// <summary>
    /// Представляет интерфейс, реализующий страницу,
    /// к которой можно прикрепить DataContext
    /// </summary>
    internal interface IPageView
    {
        /// <summary>
        /// Предоставляет доступ к презентеру данных страницы
        /// </summary>
        public object ViewModel { get; }
    }
}
