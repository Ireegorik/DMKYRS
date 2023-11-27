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
    /// Логика взаимодействия для AddNewSpeciality.xaml
    /// </summary>
    public partial class AddNewSpeciality : Window
    {
        public AddNewSpeciality()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddSpeciality(Name.Text);
            this.Close();
        }
    }
}
