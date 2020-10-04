using Master_Engine;
using System;
using System.Collections;
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

namespace Twoo
{
    /// <summary>
    /// Interaction logic for Twoo_Start_Page.xaml
    /// </summary>
    public partial class Twoo_Start_Page : Page
    {
        private static string URL = "https://twoo.com/?login=1#login";
        public Twoo_Start_Page()
        {
            InitializeComponent();
            start_the_page();
        }

        private void start_the_page()
        {
            status_Label.Content = "Loading Twoo...";
            Main_Web.Navigate(URL);
            Main_Web.LoadCompleted += Main_Web_LoadCompleted;
        }

        private void Main_Web_LoadCompleted(object sender, NavigationEventArgs e)
        {
            status_Label.Content = "Connected";
            mshtml.HTMLDocument doc = (mshtml.HTMLDocument)Main_Web.Document;
            var Raw_Email_Boxes = doc.getElementsByName("email");
            var Emails_Box_List = Raw_Email_Boxes.OfType<mshtml.HTMLInputElement>().ToList();
            int eCount1 = Emails_Box_List.Count();
            Emails_Box_List[eCount1 - 1].innerText = Engine.getUsername();

            var Raw_Password_Boxes = doc.getElementsByName("password");
            var Password_Box_List = Raw_Password_Boxes.OfType<mshtml.HTMLInputElement>().ToList();
            int eCount2 = Password_Box_List.Count();
            Password_Box_List[eCount2 - 1].innerText = Engine.getPassword();

            var Raw_Input = doc.getElementsByTagName("input");
            var Input_List = Raw_Input.OfType<mshtml.HTMLInputElement>().ToList();
            var Login_Button_List = new List<mshtml.HTMLInputElement>();
            for (int i = 0; i < Input_List.Count(); i++)
            {
                if (Input_List[i].getAttribute("type") == "submit")
                {
                    Login_Button_List.Add(Input_List[i]);
                }
            }

            int eCount3 = Login_Button_List.Count();
            Login_Button_List[eCount3 - 1].click();





        }
    }
}
