using System;
using System.Globalization;
using System.Windows.Data;
using Auction.Infrastructure.Utils;

namespace Auction.Infrastructure.ValueConverters
{
    /// <summary>
    /// Implements IValueConverter, gets enum element description
    /// </summary>
    public class EnumDescriptionConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum myEnum = (Enum)value;
            string description = EnumDescriptionHelper.GetEnumDescription(myEnum);
            return description;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.ToObject(targetType, value);
        }
    }
}
