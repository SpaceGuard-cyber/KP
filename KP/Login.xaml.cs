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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Login : Page
    {
        public static string GeneralLogin;
        public Login()
        {
            InitializeComponent();
        }

        public static int mainID;

        public void Button_Click_toPagewithfilms(object sender, RoutedEventArgs e)
        {
            try
            {
                string _login = _textBoxLogin.Text.Trim();
                GeneralLogin = _textBoxLogin.Text;
                string _password = _textBoxPassword.Password.Trim();

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
                else
                {
                    _textBoxLogin.ToolTip = "";
                    _textBoxLogin.Background = Brushes.Transparent;
                    _textBoxPassword.ToolTip = "";
                    _textBoxPassword.Background = Brushes.Transparent;

                    DataUsers _loginUser = null;
                    admins admins = null;

                    using (KPEntities db = new KPEntities())
                    {
                        admins = db.admins.Where(l => l.admin_login == _login && l.admin_password == _password).FirstOrDefault();
                        mainID = db.admins.Where(a => a.admin_login == _login).Select(x => x.id_admin).FirstOrDefault();

                        if (mainID == 0)
                        {
                            _loginUser = db.DataUsers.Where(b => b.login == _login && b.password == _password).FirstOrDefault();
                            mainID = db.DataUsers.Where(a => a.login == _login).Select(x => x.id_Users).FirstOrDefault();
                        }
                    }
                    if ((_loginUser != null) || (admins != null))
                    {
                        MessageBox.Show("You Login!");
                        NavigationService.Navigate(new Pageforeditfilm());

                    }
                    else
                        MessageBox.Show("You wrote inccorrect datas!");
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
            NavigationService.Navigate(new Signin());
        }
    }
}