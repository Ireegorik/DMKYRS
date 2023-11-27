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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void ButtonTOREG(object sender, RoutedEventArgs e)
        {
            Settings.MainFrame.Navigate(new Reg());
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            if (AuthUSER(Login.Text, Password.Text))
            {
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
}
