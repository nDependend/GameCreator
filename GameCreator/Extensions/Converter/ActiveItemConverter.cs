using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GameCreator.Extensions.Converter
{
    class ActiveItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is ViewModels.ClassPaneViewModel || value is ViewModels.ObjectPaneViewModel)
                return value;

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is ViewModels.ClassPaneViewModel || value is ViewModels.ObjectPaneViewModel)
                return value;

            return Binding.DoNothing;
        }
    }
}
