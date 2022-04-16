using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace SchedulingApp.Converters
{
    /// <summary>
    /// Представляет конвератацию в формат даты без времени
    /// </summary>
    internal class DateOnlyConverter : IValueConverter
    {
        /// <summary>
        /// Предоставляет прямую конвертацию
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime dateTime = (DateTime)value;
            string output = dateTime.ToString("d", CultureInfo.CurrentCulture);

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
