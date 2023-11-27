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

namespace DMKYRS.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterMember.xaml
    /// </summary>
    public partial class RegisterMember : Page
    {
        public RegisterMember()
        {
            InitializeComponent();
        }

        private void TeacherClick(object sender, RoutedEventArgs e)
        {
            Settings.MainFrame.Navigate(new RegisterTeacher());
        }

        private void StudentClick(object sender, RoutedEventArgs e)
        {
            Settings.MainFrame.Navigate(new RegisterStudent());
        }
    }
}
