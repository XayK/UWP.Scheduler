using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace SchedulingApp.Converters
{
    /// <summary>
    /// Представляет конвератацию в формат даты месяца
    /// </summary>
    internal class MonthOnlyConverter : IValueConverter
    {
        /// <summary>
        /// Предоставляет прямую конвертацию
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime dateTime = (DateTime)value;
            string output = string.Format("{0} - {1}", dateTime.ToString("MMMM", CultureInfo.CurrentCulture), dateTime.ToString("yyyy", CultureInfo.CurrentCulture));

            return output;
        }

        /// <summary>
        /// Предоставляет обратную конвертацию
        /// </summary>
        /// <exception cref="NotImplementedException"/>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
