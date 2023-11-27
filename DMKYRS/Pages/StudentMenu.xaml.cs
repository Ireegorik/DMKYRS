using DMKYRS.Models;
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
    /// Логика взаимодействия для StudentMenu.xaml
    /// </summary>
    public partial class StudentMenu : Page
    {
        public StudentMenu()
        {
            InitializeComponent();
            TaskList.ItemsSource = GetTasks(Settings.SG,0);
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(sender is ListView a)
            {
                if(a.SelectedItem != null)
                {
                    GetA.IsEnabled = true;
                }
                else
                {
                    GetA.IsEnabled = false;
                }
                
            }
        }

        private void GetAnswerS(object sender, RoutedEventArgs e)
        {
            DataModels.TaskS ss = (DataModels.TaskS)TaskList.SelectedItem;
            Settings.MainFrame.Navigate(new Pages.SetAnswerStudent(ss.Title,ss.About));
        }
    }
}
