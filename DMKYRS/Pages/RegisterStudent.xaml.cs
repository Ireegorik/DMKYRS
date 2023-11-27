using DMKYRS.Models;
using DMKYRS.Windows;
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
    /// Логика взаимодействия для RegisterStudent.xaml
    /// </summary>
    public partial class RegisterStudent : Page
    {
        public RegisterStudent()
        {
            InitializeComponent();
            refresh();
        }
        public void refresh()
        {
            List<DataModels.Group> ls = GetGroups();
            List<string> tittlesS = new List<string>();
            foreach (DataModels.Group s in ls)
            {
                tittlesS.Add(s.GroupNum);
            }
            Group.ItemsSource = tittlesS;
        }

        private void AddGroup(object sender, RoutedEventArgs e)
        {
            Window GroupAdd = new AddNewGroup();
            GroupAdd.Closed += GroupAdd_Closed;
            GroupAdd.Show();
        }

        private void GroupAdd_Closed(object sender, EventArgs e)
        {
            refresh();
        }

        private void RegStudents(object sender, RoutedEventArgs e)
        {
            RegStudentBD(FirstName.Text, SecondName.Text, FamalyName.Text, Group.SelectedItem.ToString(), Settings.Login);
            Settings.MainFrame.Navigate(new StudentMenu());
        }

    }
}
