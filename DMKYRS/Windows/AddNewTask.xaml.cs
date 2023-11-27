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
using System.Windows.Shapes;
using static DMKYRS.Models.Repository;

namespace DMKYRS.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewTask.xaml
    /// </summary>
    public partial class AddNewTask : Window
    {
        public AddNewTask()
        {
            InitializeComponent();
            List<DataModels.Group> ls = GetGroups();
            List<string> tittlesS = new List<string>();
            foreach (DataModels.Group s in ls)
            {
                tittlesS.Add(s.GroupNum);
            }
            Group.ItemsSource = tittlesS;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddTask(Title.Text,About.Text,Settings.SG,Group.SelectedItem.ToString(),RightAnswer.Text);
            this.Close();
        }
    }
}
