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
            using (KPEntities db = new KPEntities())
            {
                var countries = db.countries.Select(x => x.name_country).ToList();
                _addCountry.ItemsSource = countries;
                var genres = db.genres.Select(x => x.name_genre).ToList();
                _addGenre.ItemsSource = genres;
                var actor = db.creators_film.Select(x => x.actor_lastname).ToList();
                _addActor.ItemsSource = actor;
                var creator = db.creators_film.Select(x => x.actor_lastname).ToList();
                _addCreator.ItemsSource = creator;
                var film = db.films.Select(x => x.name_film).ToList();
                
                _editFilmLink.Text = db.films.Where(x => x.id_film == addfilm.filmID).Select(y => y.film_link).FirstOrDefault();
                _addRating.Text = db.films.Where(x => x.id_film == addfilm.filmID).Select(y => y.rating).FirstOrDefault().ToString();
                _addCountry.Text = db.countries.Where(x => x.id_country == addfilm.filmID).Select(y => y.name_country).FirstOrDefault();
                _addGenre.Text = db.genres.Where(x => x.id_genre == addfilm.filmID).Select(y => y.name_genre).FirstOrDefault();
                _addDateCreation.Text = db.films.Where(x => x.id_film == addfilm.filmID).Select(y => y.date_creation).FirstOrDefault().ToString();
                _addCreator.Text = db.creators_film.Where(x => x.id_creator == addfilm.filmID).Select(y => y.actor_lastname).FirstOrDefault();
                _addActor.Text = db.creators_film.Where(x => x.id_creator == addfilm.filmID).Select(y => y.actor_lastname).FirstOrDefault();

            }
        }

        public void forButton()
        {
            string editLink = _editFilmLink.Text.Trim();
            int addRating;
            DateTime addDateCreation;
            string addCountry = _addCountry.Text.Trim();
            string addGenre = _addGenre.Text.Trim();
            string addCreator = _addCreator.Text.Trim();
            string addActor = _addActor.Text.Trim();

            _addRating.ToolTip = "";
            _addRating.Background = Brushes.Transparent;
            _editFilmLink.ToolTip = "";
            _editFilmLink.Background = Brushes.Transparent;
            _addDateCreation.ToolTip = "";
            _addDateCreation.Background = Brushes.Transparent;

            addRating = Convert.ToInt32(_addRating.Text.Trim());
            addDateCreation = Convert.ToDateTime(_addDateCreation.Text.Trim());

            using (KPEntities db = new KPEntities())
            {
                var profilefilms = db.films.Where(a => a.id_film == addfilm.filmID).FirstOrDefault();

                countries editCountry = new countries();
                genres editGenre = new genres();
                creators_film addcreator = new creators_film();
                creators_film addactor = new creators_film();

                profilefilms.rating = addRating;
                profilefilms.name_film = editLink;
                editCountry.name_country = addCountry;
                profilefilms.rating = addRating;
                profilefilms.film_link = editLink;
                editGenre.name_genre = addGenre;
                profilefilms.date_creation = addDateCreation;
                addactor.actor_lastname = addActor;
                addcreator.actor_lastname = addCreator;
                db.SaveChanges();
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
