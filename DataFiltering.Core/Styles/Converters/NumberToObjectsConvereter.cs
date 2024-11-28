using System.Globalization;
using System.Windows.Data;

namespace DataFiltering.Shared.Styles.Converters
{
    public class NumberToObjectsConvereter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not int numberOfObjects || numberOfObjects < 0)
            {
                return new List<string>();
            }
            return Enumerable.Repeat("o", numberOfObjects).ToList();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
