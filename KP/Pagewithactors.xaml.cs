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
    /// Логика взаимодействия для Pagewithactors.xaml
    /// </summary>
    public partial class Pagewithactors : Page
    {
        public Pagewithactors()
        {
            InitializeComponent();
            
        }
        public void forButton()
        {
            string actor_name = _actorName.Text.Trim();
            string actor_lastname = _actorLastName.Text.Trim();
            string actor_secondname = _actorSecondName.Text.Trim();
            DateTime dateofbirth;
            DateTime dateofcareer;

            if (actor_name.Length < 3)
            {
                _actorName.ToolTip = "Incorrectly entered!";
                _actorName.Background = Brushes.Aquamarine;
            }
            if (actor_lastname.Length < 3)
            {
                _actorLastName.ToolTip = "Incorrectly entered!";
                _actorLastName.Background = Brushes.Aquamarine;
            }
            if (actor_secondname.Length < 3)
            {
                _actorSecondName.ToolTip = "Incorrectly entered!";
                _actorSecondName.Background = Brushes.Aquamarine;
            }
            try
            {
                dateofbirth = Convert.ToDateTime(_dataBirth.Text.Trim());
                dateofcareer = Convert.ToDateTime(_dataCareer.Text.Trim());

                using (KPEntities db = new KPEntities())
                {
                    creators_film creators_film = new creators_film();

                    creators_film.actor_name = actor_name;
                    creators_film.actor_lastname = actor_lastname;
                    creators_film.actor_secondname = actor_secondname;
                    creators_film.dateofbirth = dateofbirth;
                    creators_film.dateofcareer = dateofcareer;
                    db.creators_film.Add(creators_film);
                    db.SaveChanges();

                    MessageBox.Show("You saved Changes!");
                    NavigationService.Navigate(new ProfileUsers());
                }
            }
            catch
            {
                _dataBirth.ToolTip = "Incorrectly entered!";
                _dataBirth.Background = Brushes.Aquamarine;
                _dataCareer.ToolTip = "Incorrectly entered!";
                _dataCareer.Background = Brushes.Aquamarine;
            }
        }
        private void Button_forpagewithfilms(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pageforeditfilm());
        }

        private void Button_forprofile(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileUsers());
        }

        private void Button_addActor(object sender, RoutedEventArgs e)
        {
            forButton();
        }
    }
}
