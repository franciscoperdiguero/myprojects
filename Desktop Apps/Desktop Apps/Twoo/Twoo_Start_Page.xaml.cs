using Master_Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Twoo
{
    /// <summary>
    /// Interaction logic for Twoo_Start_Page.xaml
    /// </summary>
    /// 
    public partial class Twoo_Start_Page : System.Windows.Controls.Page
    {
        #region useful variables
        readonly string direct_login_url = "https://www.twoo.com/mailurl/aT0yaGgtd3o4MWVyLTN2Znl6ZzlnLXc3MjYmbD0yJnU9JTJGY29uZmlybSUyRiUzRmVtYWlsJTNEdmljYXRlbGxhJTI1NDBnbXguZGUlMjZjb2RlJTNENDEyMDI3YjM5ZWI4ZmI1M2JhMGVlN2Y0NTllNzZlZTAlMjZvcmlnaW4lM0RSRUdJU1RSQVRJT05fRk9STSslMjZyZWdpc3RyYXRpb25TdWNjZXNzJTNEMSZ0PTEmdWk9MTYwMDg0OTU1Mzg1MTEtMTk5NDA3OTI2Ny0xJTJGNyUyRjIlMkY4ODImYT03dTVjcWtfNmZiZGNkYzQ0YQ";
        readonly string logout_url = "https://www.twoo.com/login/?action=logout&amp;lng=de";
        readonly string google = "https://www.google.com";
        DispatcherTimer dTimer;

        private static int stage=0;
        private static int wait=0;

        static bool pageonceloaded = false;
        #endregion

        #region initiation
        public Twoo_Start_Page()
        {
            InitializeComponent();

           dTimer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 1),
                IsEnabled = false
            };
            // tmer click event
            dTimer.Tick += DTimer_Tick;

            // start page
            Main_Web.LoadCompleted += Main_Web_Loaded;
            Start_timer(Stages.logout_Twoo, Waits.wait_for_logout_Twoo);
        }

        #endregion

        #region timer
        private bool Start_timer(Stages page, Waits time)
        {
            stage = (int)page;
            wait = (int)time;
            dTimer.IsEnabled = true;
            dTimer.Start();
            return true;

        }

        private bool Stop_timer()
        {
            dTimer.Stop();
            dTimer.IsEnabled = false;
            wait = 0;
            return true;
        }

        private void DTimer_Tick(object sender, EventArgs e)
        {
            switch (stage)
            {
                case (int)Stages.logout_Twoo:
                    go_to_logout_Twoo_tick();
                    break;
                case (int)Stages.go_to_google_page:
                    go_to_google_page_tick(); 
                    break;
                case (int)Stages.go_to_direct_Login:
                    go_to_direct_login_tick();
                    break;
                default:
                    break;
            }

            void go_to_logout_Twoo_tick() 
            {
                if (wait >= 0)
                {
                    status_Label.Content = "I'll go to Twoo Logout in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        try_to_go_to_logout_Twoo();
                    }
                }
            }

            void go_to_google_page_tick()
            {

                if (wait >= 0)
                {
                    status_Label.Content = "I'll go to Google in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        try_to_go_to_google_page();
                    }
                }
            }

            void go_to_direct_login_tick() {
                if (wait >= 0)
                {
                    status_Label.Content = "I'll go to direct login in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        try_to_go_to_direct_login();
                    }
                }
            }
        }


        #endregion

        #region pageLoaded
        private void Main_Web_Loaded(object sender, NavigationEventArgs e)
        {
            Engine.Suppress_scripts(Main_Web);
            pageonceloaded = false;
            status_Label.Content = "";


            switch (stage)
            {
                case (int)Stages.logout_Twoo:
                    logout_Twoo_is_loaded();
                    break;
                case (int)Stages.go_to_google_page:
                    go_to_google_page_is_loaded();
                    break;
                default:                   
                    break;
            }

            void logout_Twoo_is_loaded()
            {
                if (!pageonceloaded)
                {
                    if (Main_Web.Source.ToString().Contains("twoo.com")) {
                        status_Label.Content = "Logout page loaded";
                        Start_timer(Stages.go_to_google_page, Waits.wait_for_go_to_google_page);
                        pageonceloaded = true;
                    }
                }
            }

            void go_to_google_page_is_loaded()
            {
                if (!pageonceloaded) {
                    if (Main_Web.Source.ToString().Contains("google"))
                    {
                        status_Label.Content = "Google page loaded";
                        if (Start_timer(Stages.go_to_direct_Login,Waits.wait_to_go_to_direct_Login)) { 
                            pageonceloaded = true;
                        }
                    }
                }
                
            }

        }

        #endregion

        #region navigations
        private void try_to_go_to_logout_Twoo()
        {
            Main_Web.Source = new Uri(logout_url);
        }

        private void try_to_go_to_google_page()
        {
            Main_Web.Source = new Uri(google);
        }

        private void try_to_go_to_direct_login()
        {
            Main_Web.Source = new Uri(direct_login_url);
        }

        #endregion

        //private void Main_Web_LoadCompleted()
        //{
        //if (firstime == 0) {
        //status_Label.Content = "Connected";
        //mshtml.HTMLDocument doc = (mshtml.HTMLDocument)Main_Web.Document;
        //var Raw_Email_Boxes = doc.getElementsByName("email");
        //var Emails_Box_List = Raw_Email_Boxes.OfType<mshtml.HTMLInputElement>().ToList();
        //int eCount1 = Emails_Box_List.Count();
        //Emails_Box_List[eCount1 - 1].innerText = Engine.getUsername();

        //var Raw_Password_Boxes = doc.getElementsByName("password");
        //var Password_Box_List = Raw_Password_Boxes.OfType<mshtml.HTMLInputElement>().ToList();
        //int eCount2 = Password_Box_List.Count();
        //Password_Box_List[eCount2 - 1].innerText = Engine.getPassword();

        //var Raw_Input = doc.getElementsByTagName("input");
        //var Input_List = Raw_Input.OfType<mshtml.HTMLInputElement>().ToList();
        //var Login_Button_List = new List<mshtml.HTMLInputElement>();
        //for (int i = 0; i < Input_List.Count(); i++)
        //{
        //    if (Input_List[i].getAttribute("type") == "submit")
        //    {
        //        Login_Button_List.Add(Input_List[i]);
        //    }
        //}

        //int eCount3 = Login_Button_List.Count();
        ////Login_Button_List[eCount3 - 1].click();
        //firstime = 1;
        //  }


        //}

        #region Helpers
        private enum Stages
        {
            logout_Twoo = 1,
            go_to_google_page = 2,
            go_to_direct_Login = 3
        };

        private enum Waits
        {
            wait_for_logout_Twoo = 2,
            wait_for_go_to_google_page = 3,
            wait_to_go_to_direct_Login = 3
        };

        #endregion
    }
}
