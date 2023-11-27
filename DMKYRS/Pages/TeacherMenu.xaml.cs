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
    /// Логика взаимодействия для TeacherMenu.xaml
    /// </summary>
    public partial class TeacherMenu : Page
    {
        public TeacherMenu()
        {
            InitializeComponent();
            refresh();
        }
        private void AddTask(object sender, RoutedEventArgs e)
        {
            Window SpecAdd = new AddNewTask();
            SpecAdd.Closed += AddTask_Closed;
            SpecAdd.Show();
        }
        void refresh()
        {
            TaskList.ItemsSource = GetTasks(Settings.SG, 1);
        }
        private void AddTask_Closed(object sender, EventArgs e)
        {
            refresh();
        }

    }
}
