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
        public static int GeneralID;
        public Pagewithfilms()
        {
            InitializeComponent();
            using (KPEntities db = new KPEntities())
            {
                var countries = db.countries.Select(x => x.name_country).ToList();
                _findByCountry.ItemsSource = countries;
                var genres = db.genres.Select(x => x.name_genre).ToList();
                _findByGenre.ItemsSource = genres;
                var actor = db.creators_film.Select(x => x.actor_lastname).ToList();
                _findActor.ItemsSource = actor;
                var creator = db.creators_film.Select(x => x.actor_lastname).ToList();
                _findByCreator.ItemsSource = creator;

                _findActor.Text = db.creators_film.Where(x => x.id_creator == addfilm.filmID).Select(y => y.actor_lastname).FirstOrDefault();
                _findByCreator.Text = db.creators_film.Where(x => x.id_creator == addfilm.filmID).Select(y => y.actor_lastname).FirstOrDefault();
                _findByData.Text = db.films.Where(x => x.id_film == addfilm.filmID).Select(y => y.date_creation).FirstOrDefault().ToString();
                _findByGenre.Text = db.genres.Where(x => x.id_genre == addfilm.filmID).Select(y => y.name_genre).FirstOrDefault();
                _findByCountry.Text = db.countries.Where(x => x.id_country == addfilm.filmID).Select(y => y.name_country).FirstOrDefault();


                var findFilms = db.films.Select(x => x).ToList();
                finderFilms.ItemsSource = findFilms;
            }
        }

        public void forButton()
        {

            string addActor = _findActor.Text.Trim();
            string addCreator = _findByCreator.Text.Trim();
            DateTime dateCreation;
            string addCountry = _findByCountry.Text.Trim();
            string addGenre = _findByGenre.Text.Trim();

            string proverka = _findFilm.Text.Trim();
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", $"%{proverka}%");
            using (KPEntities db = new KPEntities())
            {
                if (proverka == "")
                {
                    var findFilms = db.films.Select(x => x).ToList<films>();
                    finderFilms.ItemsSource = findFilms;
                    MessageBox.Show("Вы не ввели название фильма повторите поиск");
                }
                else
                {
                    var namefilms = db.Database.SqlQuery<films>("SELECT * FROM films WHERE name_film LIKE @name", param);
                    if (namefilms != null)
                    {
                        finderFilms.ItemsSource = namefilms.ToList();
                    }
                    else MessageBox.Show("Такого фильма не существует");
                }
            }
        }
        private void Come_Click(object sender, RoutedEventArgs e)
        {
            using (KPEntities db = new KPEntities())
            {
                try
                {
                    int idFilm = ((films)finderFilms.SelectedItem).id_film;
                    if (idFilm != 0)
                    {
                        MessageBox.Show(Convert.ToString(idFilm));
                        MessageBox.Show(((films)finderFilms.SelectedItem).name_film);
                        string proverka = _findFilm.Text.Trim();
                        GeneralID = idFilm;
                        NavigationService.Navigate(new Pagewithfilms());
                    }
                }
                catch { }
            }
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
