using System.Globalization;

namespace ForbiddenLands.App.Converters;

public class IntToObjectConverter<T> : IValueConverter
{
    public T ZeroObject { get; set; }
    public T NonZeroObject { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == 0 ? ZeroObject : NonZeroObject;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ((T)value).Equals(ZeroObject) ? 0 : 1;
    }
}
