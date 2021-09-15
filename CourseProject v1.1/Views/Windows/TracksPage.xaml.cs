using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseProject_v1._1.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для TracksPage.xaml
    /// </summary>
    public partial class TracksPage : UserControl
    {
        public TracksPage()
        {
            InitializeComponent();
        }
        private void Scroll(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            if(e.Delta < 0)
            {
                scrollViewer.LineDown();
            }
            else
            {
                scrollViewer.LineUp();
            }
            e.Handled = true;
        }

        private void ScrollViewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {

        }
    }
}
