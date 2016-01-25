using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public class Bool2ColorConverter : IValueConverter
    {
        public string TrueColor { get; set; }
        public string FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var defaultColor = "Transparent";
            if (value is bool)
            {
                //return (bool)value ? Colors.LightSalmon : Colors.Transparent;
                return (bool)value ? this.TrueColor: this.FalseColor;
            }
            return defaultColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if(value is Color)
            {
                return (Color)value == Colors.LightSalmon ? true : false;
            }
            else
            {
                return false;
            }
        }
    }
}
