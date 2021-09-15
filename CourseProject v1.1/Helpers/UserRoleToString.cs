using CourseProject_v1._1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CourseProject_v1._1.Helpers
{
    class UserRoleToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case 0:
                    {
                        return "User";
                    }
                case 1:
                    {
                        return "Signer";
                    }
                case 2:
                    {
                        return "Admin";
                    }
                case 3:
                    {
                        return "Anonim";
                    }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
