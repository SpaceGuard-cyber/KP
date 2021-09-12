using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для addfilm.xaml
    /// </summary>
    public partial class addfilm : Page
    {
        public addfilm()
        {
            InitializeComponent();
            using (KPEntities db = new KPEntities())
            {
                _addByData.Text = db.films.Where(x => x.id_film == addfilm.filmID).Select(y => y.date_creation).FirstOrDefault().ToString();                
            }
        }

        public static int filmID;
        private static byte[] ImagetoByte;

        private void Button_AddFilm(object sender, RoutedEventArgs e)
        {
            try
            {
                string name_film = _addFilm.Text.Trim();
                string Link = _addFilmLink.Text.Trim();
                string testdate = _addByData.Text.Trim();
                if (name_film.Length < 5)
                {
                    _addFilm.ToolTip = "Incorrectly entered!";
                    _addFilm.Background = Brushes.Aquamarine;
                }
                else if (Link.Length < 5)
                {
                    _addFilmLink.ToolTip = "Incorrectly entered!";
                    _addFilmLink.Background = Brushes.Aquamarine;
                }
                else
                {
                    _addFilm.ToolTip = "";
                    _addFilm.Background = Brushes.Transparent;
                    _addFilmLink.ToolTip = "";
                    _addFilmLink.Background = Brushes.Transparent;

                    films addfilms = null;
                    using (KPEntities db = new KPEntities())
                    {
                        addfilms = db.films.Where(b => b.name_film == name_film && b.film_link == Link).FirstOrDefault();
                        filmID = db.films.Where(a => a.name_film == name_film).Select(x => x.id_film).FirstOrDefault();
                        films addFilm = new films();

                        addFilm.name_film = name_film;
                        addFilm.date_creation = Convert.ToDateTime(testdate);
                        addFilm.film_photo = ImagetoByte;
                        addFilm.film_link = Link;

                        db.films.Add(addFilm);
                        db.SaveChanges();

                        MessageBox.Show("You added film!");
                        NavigationService.Navigate(new ProfileUsers());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Connections failed!");
                Application.Current.Shutdown();
            }
        }

        private void Button_Choosephoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select a photo";
            ofd.Filter = "Image Files | *.BMP; *.JPG; *.PNG";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == true)
            {
                MessageBox.Show("Выбран файл " + ofd.FileName);
            }
            try
            {
                ImageSource III1 = new BitmapImage(new Uri(ofd.FileName));
                addfilm.ImagetoByte = File.ReadAllBytes(ofd.FileName);
            }
            catch
            {
                MessageBox.Show("Вы не выбрали фотографию");
            }
        }
        private void Button_forprofile(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileUsers());
        }

        private void Button_forpagewithfilms(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pagewithfilms());
        }

        private void Button_editfilm(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pageforeditfilm());
        }

        private void Button_foractors(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pagewithactors());
        }
    }
}
