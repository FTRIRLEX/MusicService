using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CourseProject_v1._1.Helpers
{
    class TrackToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (File.Exists( $@"D:\MusicService\{(int)value}\cover.jpg"))
            {
                return $@"D:\MusicService\{(int)value}\cover.jpg";
            }
            else
            {
                return $@"D:\MusicService\NoPhoto.png";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter,
           System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
