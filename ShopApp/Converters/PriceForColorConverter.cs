﻿using System.Globalization;

namespace ShopApp.Converters;

public class PriceForColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var precio = (decimal)value;
        if (precio >= 0 && precio <= 100)
        {
            return Colors.Green;
        }

        return Colors.Red;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
