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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class ProfileUsers : Page
    {

        public ProfileUsers()
        {
            InitializeComponent();
            using (KPEntities db = new KPEntities())
            {
                _userName.Text = db.Users.Where(x => x.id_users == Login.mainID).Select(y => y.user_name).FirstOrDefault();
                _userLastName.Text = db.Users.Where(x => x.id_users == Login.mainID).Select(y => y.user_lastname).FirstOrDefault();
                _userSecondName.Text = db.Users.Where(x => x.id_users == Login.mainID).Select(y => y.user_secondname).FirstOrDefault();
                _dataBirth.Text = db.Users.Where(x => x.id_users == Login.mainID).Select(y => y.dataofbirth).FirstOrDefault().ToString();
                _email.Text = db.Users.Where(x => x.id_users == Login.mainID).Select(y => y.user_name).FirstOrDefault();
            }
        }
        public void forButton()
        {
            string userName = _userName.Text.Trim();
            string lastName = _userLastName.Text.Trim();
            string secondName = _userSecondName.Text.Trim();
            DateTime dataofbirth;
            string email = _email.Text.Trim();

            if (userName.Length < 3)
            {
                _userName.ToolTip = "Incorrectly entered!";
                _userName.Background = Brushes.Aquamarine;
            }
            if (lastName.Length < 3)
            {
                _userLastName.ToolTip = "Incorrectly entered!";
                _userLastName.Background = Brushes.Aquamarine;
            }
            if (secondName.Length < 3)
            {
                _userSecondName.ToolTip = "Incorrectly entered!";
                _userSecondName.Background = Brushes.Aquamarine;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                _email.ToolTip = "Incorrectly entered!";
                _email.Background = Brushes.Aquamarine;
            }
            try
            {
                dataofbirth = Convert.ToDateTime(_dataBirth.Text.Trim());

                using (KPEntities db = new KPEntities())
                {
                    var profileUser = db.Users.Where(a=>a.id_users==Login.mainID).FirstOrDefault();

                    profileUser.user_name = userName;
                    profileUser.user_lastname = lastName;
                    profileUser.user_secondname = secondName;
                    profileUser.dataofbirth = dataofbirth;
                    profileUser.email = email;
                    db.SaveChanges();

                    MessageBox.Show("You saved Changes!");
                    NavigationService.Navigate(new ProfileUsers());
                }
            }
            catch
            {
                _dataBirth.ToolTip = "Incorrectly entered!";
                _dataBirth.Background = Brushes.Aquamarine;
            }
        }

        private void Button_foraddfilms(object sender, RoutedEventArgs e)  
        {
            NavigationService.Navigate(new addfilm());
        }

        private void Button_forpagewithfilms(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new Pagewithfilms());
        }

        private void Button_SaveChanges(object sender, RoutedEventArgs e)
        {
            forButton();
        }
    }
}

