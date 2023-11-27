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
using static DMKYRS.Models.Repository;
namespace DMKYRS.Pages
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }


        private void ButtonTOAUTH(object sender, RoutedEventArgs e)
        {
            Settings.MainFrame.Navigate(new Auth());
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            RegisterUSER(Login.Text, Password.Text);
            Settings.Login = Login.Text;
            switch (IsRegUser(Settings.Login))
            {
                case 0:
                    Settings.MainFrame.Navigate(new RegisterMember());
                    break;

                case 1:
                    Settings.SG = GetGroupOrSpeciality(Settings.Login, 0);
                    Settings.MainFrame.Navigate(new StudentMenu());
                    break;

                case 2:
                    Settings.SG = GetGroupOrSpeciality(Settings.Login, 1);
                    Settings.MainFrame.Navigate(new TeacherMenu());
                    break;
            }
        }
    }
}
