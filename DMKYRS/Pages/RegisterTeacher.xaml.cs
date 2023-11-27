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
using DMKYRS.Windows;
using DMKYRS.Models;

namespace DMKYRS.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterTeacher.xaml
    /// </summary>
    public partial class RegisterTeacher : Page
    {
        public RegisterTeacher()
        {
            InitializeComponent();
            refresh();
        }
        public void refresh()
        {
            List<DataModels.Speciality> ls = GetSpecialities();
            List<string> tittlesS = new List<string>();
            foreach(DataModels.Speciality s in ls)
            {
                tittlesS.Add(s.Title);
            }
            Speciality.ItemsSource = tittlesS;
        }
        
        private void AddSpec(object sender, RoutedEventArgs e)
        {
            Window SpecAdd = new AddNewSpeciality();
            SpecAdd.Closed += SpecAdd_Closed;
            SpecAdd.Show();
        }

        private void SpecAdd_Closed(object sender, EventArgs e)
        {
            refresh();
        }

        private void RegTeacher(object sender, RoutedEventArgs e)
        {
            RegTeacherBD(FirstName.Text, SecondName.Text, FamalyName.Text, Speciality.SelectedItem.ToString(), Settings.Login);
            Settings.MainFrame.Navigate(new TeacherMenu());
        }
    }
}
