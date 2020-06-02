using System;
using System.Globalization;

using Xamarin.Forms;

namespace Param_RootNamespace.Converters
{
    public class ItemTappedEventArgsToItemTappedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as ItemTappedEventArgs;
            return eventArgs != null ? eventArgs.Item : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
