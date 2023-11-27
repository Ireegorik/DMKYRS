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
    /// Логика взаимодействия для SetAnswerStudent.xaml
    /// </summary>
    public partial class SetAnswerStudent : Page
    {
        public SetAnswerStudent(string TitleS,string AboutS)
        {
            InitializeComponent();
            Title.Content = TitleS;
            About.Content = AboutS;
           if( StudentAnswerQWZ(Settings.Login, TitleS, AboutS))
           {
                BB.IsEnabled = false;
           }
           else
           {
                BB.IsEnabled = true;
           }
        }

        private void AnswerB(object sender, RoutedEventArgs e)
        {
            GetAnswer(Settings.Login, Title.Content.ToString(), About.Content.ToString(), Answer.Text);
            BB.IsEnabled = false;
            Settings.MainFrame.Navigate(new Pages.StudentMenu());
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            Settings.MainFrame.Navigate(new Pages.StudentMenu());
        }
    }
}
