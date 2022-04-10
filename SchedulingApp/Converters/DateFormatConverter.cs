using System;
using Windows.UI.Xaml.Data;

namespace SchedulingApp.Converters
{
    /// <summary>
    /// Предоставляет конвертер формата <see cref="DateTime"/> в <see cref="DateTimeOffset"/>
    /// </summary>
    internal class DateFormatConverter : IValueConverter
    {
        /// <summary>
        /// Предоставляет прямую конвертацию
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime dateTime = (DateTime)value;
            DateTimeOffset dateTimeOffset = new(dateTime);

            return dateTimeOffset;
        }

        /// <summary>
        /// Предоставляет обратную конвертацию
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset dateTimeOffset = (DateTimeOffset)value;
            DateTime dateTime = dateTimeOffset.DateTime;

            return dateTime;
        }
    }
}
