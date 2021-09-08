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
    /// Логика взаимодействия для Pageforeditfilm.xaml
    /// </summary>
    public partial class Pageforeditfilm : Page
    {
        public Pageforeditfilm()
        {
            InitializeComponent();
            
        }

        public void forButton()
        {
            using (KPEntities db = new KPEntities())
            {
                var countries = db.countries.Select(x => x.name_country).ToList();
                _addCountry.ItemsSource = countries;
                var genres = db.genres.Select(x => x.name_genre).ToList();
                _addGenre.ItemsSource = genres;
                var actor = db.creators_film.Select(x => x.actor_lastname).ToList();
                _addActor.ItemsSource = actor;

            }
        }

        private void Button_forpagewithfilms(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pagewithfilms());
        }

        private void Button_forprofile(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileUsers());
        }

        private void Button_savechanges(object sender, RoutedEventArgs e)
        {
            forButton();
        }
    }
}
