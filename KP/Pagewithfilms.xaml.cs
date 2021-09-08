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

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для Pagewithfilms.xaml
    /// </summary>
    public partial class Pagewithfilms : Page
    {
        public Pagewithfilms()
        {
            InitializeComponent();
        }

        private void Button_foraddfilms(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new addfilm());
        }

        private void Button_forprofile(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileUsers());
        }

        private void Button_FindFilm(object sender, RoutedEventArgs e)
        {

        }
    }
}
