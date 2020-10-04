using Master_Engine;
using Microsoft.Win32;
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
using System.Text.RegularExpressions;
using System.Windows.Media.Converters;

namespace Twoo
{
    /// <summary>
    /// Interaction logic for Input_Parameters.xaml
    /// </summary>
    public partial class Input_Parameters : Page
    {

        public Input_Parameters()
        {
            InitializeComponent();
        }

        public void Btn_Click_Start(object sender, RoutedEventArgs e)
        {
            resetStatusComponents();
            bool error = false;
            bool validEmail = false;
            bool introducedPass = false;
            bool introducedMessage = false;
            if (Valid_Email(Username_Box.Text)) {
                validEmail = true;
            }else error = true;

            if (Password_Box.Password != "") {
                introducedPass = true;
            }else error = true;

            if (Message_Box.Text != "") {
                introducedMessage = true;
            }else error = true;


            if (error == true)
            {
                string err = "";

                if (!validEmail)
                {
                    err += "Wrong Email.";
                    Username_Box.BorderBrush = Brushes.Red;
                }
                if (!introducedPass)
                {
                    err += "Empty Password.";
                    Password_Box.BorderBrush = Brushes.Red;
                }
                if (!introducedMessage)
                {
                    err += "Empty Message.";
                    Message_Box.BorderBrush = Brushes.Red;
                }
                Error_Message.Content = err;
                Error_Message.Visibility = Visibility.Visible;
            }
            else {

                bool u = Engine.setUsername(Username_Box.Text);
                bool p = Engine.setPassword(Password_Box.Password);
                bool m = Engine.setMessage(Message_Box.Text);

                if(u && p && m)
                {
                    NavigationService ns = NavigationService.GetNavigationService(this);
                    ns.Navigate(new Uri("Twoo_Start_Page.xaml", UriKind.RelativeOrAbsolute));
                }
            }

        }

        private void resetStatusComponents() {
            Error_Message.Visibility = Visibility.Hidden;
            var color = Color.FromArgb(100, 0, 120, 215);
            Username_Box.BorderBrush = new SolidColorBrush(color);
            Password_Box.BorderBrush = new SolidColorBrush(color);
            Message_Box.BorderBrush = new SolidColorBrush(color);
        }

        private Boolean Valid_Email(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
