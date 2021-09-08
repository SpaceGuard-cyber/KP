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
    /// Логика взаимодействия для Signin.xaml
    /// </summary>
    public partial class Signin : Page
    {
        public Signin()
        {
            InitializeComponent();
        }

        public void Button_Signin_Click(object sender, RoutedEventArgs e)
        {        
            try
            {
                string _login = _textBoxLogin.Text.Trim();
                string _password = _textBoxPassword.Password.Trim();
                string _repeatPassword = _textBoxRepeatPassword.Password.Trim();
                if (_login.Length < 5)
                {
                    _textBoxLogin.ToolTip = "Incorrectly entered!";
                    _textBoxLogin.Background = Brushes.Aquamarine;
                }
                else if (_password.Length < 5)
                {
                    _textBoxPassword.ToolTip = "Incorrectly entered!";
                    _textBoxPassword.Background = Brushes.Aquamarine;
                }
                else if (_repeatPassword != _password)
                {
                    _textBoxRepeatPassword.ToolTip = "Incorrectly entered!";
                    _textBoxRepeatPassword.Background = Brushes.Aquamarine;
                }
                else
                {
                    _textBoxLogin.ToolTip = "";
                    _textBoxLogin.Background = Brushes.Transparent;
                    _textBoxPassword.ToolTip = "";
                    _textBoxPassword.Background = Brushes.Transparent;
                    _textBoxRepeatPassword.ToolTip = "";
                    _textBoxRepeatPassword.Background = Brushes.Transparent;


                    using (KPEntities db = new KPEntities())
                    {
                        Users AddUser = new Users();

                        DataUsers users = new DataUsers();

                        users.login = _login;
                        users.password = _password;

                        db.Users.Add(AddUser);
                        db.SaveChanges();
                        users.id_Users = db.Users.OrderByDescending(x => x.id_users).Select(y => y.id_users).FirstOrDefault();
                        db.DataUsers.Add(users);
                        db.SaveChanges();

                        MessageBox.Show("You signin!");
                        NavigationService.Navigate(new Login());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Connections failed!");
                Application.Current.Shutdown();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
