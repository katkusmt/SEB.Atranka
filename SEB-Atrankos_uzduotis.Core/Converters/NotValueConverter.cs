using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEB_Atrankos_uzduotis.Core.Converters
{
    public class NotValueConverter : MvxValueConverter<bool, bool>
    {
        protected override bool Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !value;
        }

        protected override bool ConvertBack(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !value;
        }
    }
}
