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
        public static int GeneralID;
        public Pageforeditfilm()
        {
            InitializeComponent();

            using (KPEntities db = new KPEntities())
            {
            //    _addActor.Text = db.creators_film.Where(x => x.id_creator == addfilm.filmID).Select(y => y.actor_lastname).FirstOrDefault();
            //    _addCreator.Text = db.creators_film.Where(x => x.id_creator == addfilm.filmID).Select(y => y.actor_lastname).FirstOrDefault();
            //    _addRating.Text = db.films.Where(x => x.id_film == addfilm.filmID).Select(y => y.rating).FirstOrDefault().ToString();
            //    _dateCreation.Text = db.films.Where(x => x.id_film == addfilm.filmID).Select(y => y.date_creation).FirstOrDefault().ToString();
            //    _addGenre.Text = db.genres.Where(x => x.id_genre == addfilm.filmID).Select(y => y.name_genre).FirstOrDefault();
            //    _addCountry.Text = db.countries.Where(x => x.id_country == addfilm.filmID).Select(y => y.name_country).FirstOrDefault();


                var editFilms = db.films.Select(x => x).ToList();
                editorFilms.ItemsSource = editFilms;
            }
        }

        public void forButton()
        {

            //string addActor = _addActor.Text.Trim();
            //string addCreator = _addCreator.Text.Trim();
            //string addRating = _addRating.Text.Trim();
            //DateTime dateCreation;
            //string addCountry = _addCountry.Text.Trim();
            //string addGenre = _addGenre.Text.Trim();

            string proverka = _editfilm.Text.Trim();
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", $"%{proverka}%");
            using (KPEntities db = new KPEntities())
            {
                if (proverka == "")
                {
                    var editFilms = db.films.Select(x => x).ToList<films>();
                    editorFilms.ItemsSource = editFilms;
                    MessageBox.Show("Вы не ввели название фильма повторите поиск");
                }
                else
                {
                    var namefilms = db.Database.SqlQuery<films>("SELECT * FROM films WHERE name_film LIKE @name", param);
                    if (namefilms != null)
                    {
                        editorFilms.ItemsSource = namefilms.ToList();
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
                    int idFilm = ((films)editorFilms.SelectedItem).id_film;
                    if (idFilm != 0)
                    {
                        MessageBox.Show(Convert.ToString(idFilm));
                        MessageBox.Show(((films)editorFilms.SelectedItem).name_film);
                        string proverka = _editfilm.Text.Trim();
                        GeneralID = idFilm;
                        NavigationService.Navigate(new Pageforeditfilm());
                    }
                }
                catch { }
            }
        }
        //Удаление Фильма
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (KPEntities db = new KPEntities())
                {
                    if (db.admins.Where(x => x.admin_login == Login.GeneralLogin).Select(x => x).FirstOrDefault() != null)
                    {
                        int idFilm = ((films)editorFilms.SelectedItem).id_film;
                        if (idFilm != 0)
                        {
                            MessageBox.Show(Convert.ToString(idFilm));
                            MessageBox.Show(((films)editorFilms.SelectedItem).name_film);
                            string proverka = _editfilm.Text.Trim();
                            GeneralID = idFilm;
                            var getIDFILM = db.films.Where(x => x.id_film == Pageforeditfilm.GeneralID).Select(y => y).FirstOrDefault();
                            db.films.Remove(getIDFILM);
                            db.SaveChanges();
                            var editFilms = db.films.Select(x => x).ToList<films>();
                            editorFilms.ItemsSource = editFilms;
                        }
                    }
                    else { MessageBox.Show("You are not admin"); }
                }
            }
            catch { }
        }
        //Изменение фильма 
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idFilm = ((films)editorFilms.SelectedItem).id_film;
                if (idFilm != 0)
                {
                    MessageBox.Show(Convert.ToString(idFilm));
                    MessageBox.Show(((films)editorFilms.SelectedItem).name_film);
                    string PROV1 = _editfilm.Text.Trim();
                    GeneralID = idFilm;
                    using (KPEntities db = new KPEntities())
                    {
                        if (db.admins.Where(x => x.admin_login == Login.GeneralLogin).Select(x => x).FirstOrDefault() != null)
                        {
                            NavigationService.Navigate(new Pageforeditfilm());
                        }
                        else { MessageBox.Show("You are not admin"); }
                    }
                }
            }
            catch
            {

            }
        }


        private void Button_savechanges(object sender, RoutedEventArgs e)
        {
            forButton();
        }

        private void Button_forprofile(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileUsers());
        }

        private void Button_forpageaddfilms(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new addfilm());
        }
    }
}