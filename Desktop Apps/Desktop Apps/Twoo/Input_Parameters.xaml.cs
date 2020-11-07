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
using System.Windows.Forms;
using System.IO;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace Twoo
{
    /// <summary>
    /// Interaction logic for Input_Parameters.xaml
    /// </summary>
    public partial class Input_Parameters : Page
    {

        #region variables
        Dictionary<String, Dictionary<String, String>> data;
        #endregion

        public Input_Parameters()
        {
            InitializeComponent();
        }

        public void Btn_Click_Start(object sender, RoutedEventArgs e)
        {
            resetStatusComponents();
            bool error = false;
            bool validEmail = false;
            if (Valid_Email(Username_Box.Text))
            {
                validEmail = true;
            }
            else error = true;


            if (error == true)
            {
                string err = "";

                if (!validEmail)
                {
                    err += "Please, select an email.";
                    Username_Box.BorderBrush = Brushes.Red;
                }
                Error_Message.Content = err;
                Error_Message.Visibility = Visibility.Visible;
            }
            else
            {
                String user = String.Empty;
                String msg = String.Empty;
                String link = String.Empty;

                bool u = false;
                bool m = false;
                bool l = false;

                if ((user = Username_Box.Text) != String.Empty) {
                    u = Engine.setUsername(user);
                }
                if ((msg = data[Username_Box.Text].Keys.ToList<string>()[0]) != String.Empty) { 
                    m = Engine.setMessage(msg);
                }

                if ((link = data[Username_Box.Text].Values.ToList<string>()[0]) != String.Empty) { 
                    l = Engine.setDirectLink(link);
                }
          
                if (u && m && l)
                {
                    NavigationService ns = NavigationService.GetNavigationService(this);
                    ns.Navigate(new Uri("Twoo_Start_Page.xaml", UriKind.RelativeOrAbsolute));
                }
            }

        }

        private void resetStatusComponents()
        {
            Error_Message.Visibility = Visibility.Hidden;
            var color = Color.FromArgb(100, 0, 120, 215);
            Username_Box.BorderBrush = new SolidColorBrush(color);
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

        private void Btn_Open_Browser_File(object sender, RoutedEventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "txt files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName;
                File_selected.Content = theDialog.SafeFileName;
                string[] filelines = File.ReadAllLines(filename);

                data = new Dictionary<string, Dictionary<string, string>>();

                int i = 0;
                while (i < filelines.Length) {

                    if (filelines[i].Contains("@") && filelines[i].Length < 30)
                    {
                        Dictionary<String, String> aux = new Dictionary<string, string>();
                        aux.Add(filelines[i + 1], filelines[i + 2]);
                        data.Add(filelines[i], aux);
                        i += 3;
                    }
                    i++;
                }
                Username_Box.ItemsSource = data.Keys.ToList<string>();
            }

        }
    }
}
