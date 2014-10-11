using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace GameCreator.Extensions.Converter
{
    class ImageToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value.Length > 1 && value[0] is BitmapImage && value[1] is string))
                return Binding.DoNothing;
            BitmapImage bi = value[0] as BitmapImage;
            switch((string)value[1])
            {
                case "Stretch":
                    return new ImageBrush(bi);
                case "Tile":
                    return new ImageBrush(bi)
                    {
                        TileMode = TileMode.Tile,
                        ViewportUnits = BrushMappingMode.Absolute,
                        Viewport = new System.Windows.Rect(0,0,bi.Width,bi.Height)
                    };
                default:
                    return new ImageBrush(bi)
                    {
                        ViewportUnits = BrushMappingMode.Absolute,
                        Viewport = new System.Windows.Rect(0,0,bi.Width,bi.Height)
                    };

            }
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
