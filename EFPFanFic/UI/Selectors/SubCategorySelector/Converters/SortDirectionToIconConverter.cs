using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace EFPFanFic.UI.Selectors.SubCategorySelector.Converters
{
    public class SortDirectionToIconConverter: MarkupExtension, IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is bool)
            {
                if((bool)value)
                    return new BitmapImage(new Uri(@"pack://application:,,,/EFPFanFic;component/Images/control-270.png"));
                else
                    return new BitmapImage(new Uri(@"pack://application:,,,/EFPFanFic;component/Images/control-090.png"));
            }
                
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
