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
    /// Логика взаимодействия для AddNewGroup.xaml
    /// </summary>
    public partial class AddNewGroup : Window
    {
        public AddNewGroup()
        {
            InitializeComponent();
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            AddGroup(Name.Text);
            this.Close();
        }
    }
}
