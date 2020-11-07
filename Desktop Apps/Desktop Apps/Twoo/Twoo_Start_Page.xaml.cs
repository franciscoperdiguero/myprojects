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
        readonly string direct_login_url = Engine.getDirectLink();
        readonly string logout_url = "https://www.twoo.com/login/?action=logout&amp;lng=de";
        readonly string google = "https://www.google.com";
        readonly string Twoo_messages_url = "https://www.twoo.com/messages";
        readonly string Twoo_message_select_by_id_url = "https://www.twoo.com/messages/?id=";
        readonly string className1 = "tw3-person";
        readonly string className2 = "unread";
        readonly string className3 = "clearfix";
        readonly string Twoo_message_box = "jsChatInput tw3-textarea";
        readonly string Twoo_send_button = "jsSubmitButton bottomBar__actions__submit";
        private static List<string> messageLinks = new List<string>();


        private string currentlink;
        DispatcherTimer dTimer;

        private static int stage=0;
        private static int wait=0;

        static bool pageonceloaded = false;
        #endregion

        #region initiation
        public Twoo_Start_Page()
        {
            InitializeComponent();

            button_start_stop.MouseLeftButtonDown += Button_start_stop_MouseLeftButtonDown;

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

        private void Button_start_stop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            status_Label.Content = "The program will stop...";
            Start_timer(Stages.stop_program, Waits.wait_to_stop);
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
                case (int)Stages.go_to_Twoo_messages:
                    go_to_Twoo_messages_tick();
                    break;
                case (int)Stages.gather_messages:
                    go_to_gather_messages_tick();
                    break;
                case (int)Stages.navigate_to_unread_messages:
                    navigate_to_unread_messages_tick();
                    break;
                case (int)Stages.inject_message:
                    inject_messages_tick();
                    break;
                case (int)Stages.send_message:
                    send_message_tick();
                    break;
                case (int)Stages.stop_program:
                    stop_program_tick();
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

            void go_to_Twoo_messages_tick()
            {
                if (wait >= 0)
                {
                    status_Label.Content = "I'll go to Twoo messages in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        try_to_go_to_Twoo_messages();
                    }
                }
            }

            void go_to_gather_messages_tick() {
                if (wait >= 0)
                {
                    status_Label.Content = "I'll try to gather messages in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        try_to_gather_messages();
                    }
                }
            }

            void navigate_to_unread_messages_tick()
            {
                if (wait >= 0)
                {
                    status_Label.Content = "I'll try to navigate to unread messages in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        Try_to_navigate_to_unread_messages();
                    }
                }
            }

            void inject_messages_tick() {
                if(wait >= 0)
                {
                    status_Label.Content = "I'll try to inject the message in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        Try_to_inject_message();
                    }
                }
            }

            void send_message_tick()
            {
                if (wait >= 0)
                {
                    status_Label.Content = "I'll send the message in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        Try_to_send_message();
                    }
                }
            }

            void stop_program_tick()
            {
                if (wait >= 0)
                {
                    status_Label.Content = "I'll stop the program in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        Try_to_stop_program();
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


            switch (stage)
            {
                case (int)Stages.logout_Twoo:
                    logout_Twoo_is_loaded();
                    break;
                case (int)Stages.go_to_google_page:
                    go_to_google_page_is_loaded();
                    break;
                case (int)Stages.go_to_direct_Login:
                    go_to_direct_Login_is_loaded();
                    break;
                case (int)Stages.go_to_Twoo_messages:
                    go_to_Twoo_messages_is_loaded();
                    break;
                case (int)Stages.navigate_to_unread_messages:
                    navigate_to_unread_message_is_loaded();
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
                else
                {
                    status_Label.Content = "Logout page is not found";
                }
            }

            void go_to_google_page_is_loaded()
            {
                if (!pageonceloaded) {
                    if (Main_Web.Source.ToString().Contains("google"))
                    {
                        status_Label.Content = "Google page loaded";
                        if (Start_timer(Stages.go_to_direct_Login, Waits.wait_to_go_to_direct_Login))
                        {
                            pageonceloaded = true;
                        }
                    }
                    else {
                        status_Label.Content = "Google page is not found";
                    }
                }
                
            }

            void go_to_direct_Login_is_loaded()
            {
                if (!pageonceloaded)
                {
                    if (Main_Web.Source.ToString().Contains("twoo") && Main_Web.Source.ToString().Contains("game"))
                    {
                        status_Label.Content = "Twoo login page loaded";
                        if (Start_timer(Stages.go_to_Twoo_messages, Waits.wait_to_go_to_Twoo_messages))
                        {
                            pageonceloaded = true;
                        }
                    }
                }
                else
                {
                    status_Label.Content = "Twoo login page is not found";
                }
            }

            void go_to_Twoo_messages_is_loaded()
            {
                if (!pageonceloaded)
                {
                    if (Main_Web.Source.ToString().Contains("twoo") && Main_Web.Source.ToString().Contains("messages"))
                    {
                        status_Label.Content = "Twoo messages page loaded";
                        if (Start_timer(Stages.gather_messages, Waits.wait_to_gather_messages))
                        {
                            pageonceloaded = true;
                        }
                    }
                }
                else
                {
                    status_Label.Content = "Twoo messages is not found";
                }
            }

            void navigate_to_unread_message_is_loaded()
            {
                if (!pageonceloaded)
                {
                    string current = currentlink.Split('=')[1]?.ToString();
                    if (Main_Web.Source.ToString().Contains("twoo") && Main_Web.Source.ToString().Contains("messages") && Main_Web.Source.ToString().Contains(current))
                    {
                        status_Label.Content = "First unread message loaded";
                        if (Start_timer(Stages.inject_message, Waits.wait_to_inject_message))
                        {
                            pageonceloaded = true;
                        }
                    }
                }
                else
                {
                    status_Label.Content = "Unread message not found";
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

        private void try_to_go_to_Twoo_messages() {
            Main_Web.Source = new Uri(Twoo_messages_url);
        }

        private void try_to_gather_messages() {
            status_Label.Content = "Gathering messages...";

            #region to close model
            if (Close_models())
            {
                now_gather_messages();
            }   
            #endregion

            void now_gather_messages()
            {
                mshtml.HTMLDocument doc = (mshtml.HTMLDocument)Main_Web.Document;
                var Raw_Person_List = doc.getElementsByTagName("li");
                var Person_list = Raw_Person_List.OfType<mshtml.HTMLLIElement>().ToList();
                if (Person_list != null && Person_list.Count() > 0)
                {

                    Person_list.ForEach(person =>
                    {
                        string classname = person.getAttribute("className");

                        if (classname != null)
                        {
                            if (classname.Contains(className1) && classname.Contains(className2))
                            {
                                string identifier = person.getAttribute("data-id");
                                messageLinks.Add(Twoo_message_select_by_id_url + identifier);
                            }
                            else if (classname.Contains(className1) && classname.Contains(className2) && classname.Contains(className3))
                            {
                                string identifier = person.getAttribute("data-id");
                                messageLinks.Add(Twoo_message_select_by_id_url + identifier);
                            }
                        }

                    });
                    
                    if (messageLinks.Count() > 0)
                    {
                        status_Label.Content = "I have found " + messageLinks.Count() + " messages unread";
                        Start_timer(Stages.navigate_to_unread_messages, Waits.wait_navigate_to_unread_messages);
                    }
                    else
                    {
                        status_Label.Content = "No person found";
                        Start_timer(Stages.stop_program, Waits.wait_to_stop);
                    }
                }
            }
        }

        private void Try_to_navigate_to_unread_messages() {
            if (messageLinks.Count() > 0)
            {
                status_Label.Content = "Navigating to an unread message";
                currentlink = messageLinks.First();
                List<string> new_list = messageLinks.Skip(1).ToList();
                messageLinks = new_list;
                Main_Web.Navigate(currentlink);
            }
            else {
                status_Label.Content = "There is no message to work on";
                Start_timer(Stages.stop_program, Waits.wait_to_stop);
            }
            
        }

        private void Try_to_inject_message()
        {
            mshtml.HTMLDocument doc = (mshtml.HTMLDocument)Main_Web.Document;

            #region to accept chatting
            if (Accept_chatting())
            {
                if (!Is_duplicate(doc))
                {
                    now_inject_message();
                }
                else
                {
                    status_Label.Content = "This user already have the message.";
                    Start_timer(Stages.navigate_to_unread_messages, Waits.wait_navigate_to_unread_messages);
                }
            }
            #endregion

            void now_inject_message()
            {
                var Raw_Message_Box = doc.getElementsByTagName("textarea");
                var Message_Box_list = Raw_Message_Box.OfType<mshtml.HTMLTextAreaElement>().ToList();
                if (Message_Box_list != null && Message_Box_list.Count() > 0)
                {
                    Message_Box_list.ForEach(box =>
                    {
                        string classname = box.getAttribute("className");

                        if (classname != null)
                        {
                            if (classname.Contains(Twoo_message_box))
                            {
                                box.click();
                                box.focus();
                                box.innerText = Engine.getMessage();
                            }
                        }

                    });
                }
                else {
                    status_Label.Content = "No input box found";
                }
            }
            status_Label.Content = "Message injected succesfully.";
            Start_timer(Stages.send_message, Waits.wait_to_send_message);
        }

        private void Try_to_send_message()
        {
            mshtml.HTMLDocument doc = (mshtml.HTMLDocument)Main_Web.Document;
            var Raw_Anchor_Button = doc.getElementsByTagName("a");
            var Anchor_Button_List = Raw_Anchor_Button.OfType<mshtml.HTMLAnchorElement>().ToList();

            if (Anchor_Button_List != null && Anchor_Button_List.Count() > 0) {
                Anchor_Button_List.ForEach(anchor =>
                {
                    string classname = anchor.getAttribute("className");

                    if (classname != null) {
                        if (classname.Contains(Twoo_send_button)) {
                            anchor.click();
                        }
                    }
                });
                Start_timer(Stages.navigate_to_unread_messages, Waits.wait_navigate_to_unread_messages);
            }
        }

        private void Try_to_stop_program()
        {
            //TODO Clear all the fields
            currentlink = string.Empty;
            Main_Web.Navigate(logout_url);
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Input_Parameters.xaml", UriKind.RelativeOrAbsolute));
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

        //Test
        //}

        #region Helpers
        private enum Stages
        {
            logout_Twoo = 1,
            go_to_google_page = 2,
            go_to_direct_Login = 3,
            go_to_Twoo_messages = 4,
            gather_messages = 5,
            navigate_to_unread_messages= 6,
            inject_message = 7,
            send_message = 8,
            stop_program = 9
        };

        private enum Waits
        {
            wait_for_logout_Twoo = 1,
            wait_for_go_to_google_page = 3,
            wait_to_go_to_direct_Login = 3,
            wait_to_go_to_Twoo_messages = 3,
            wait_to_gather_messages = 3,
            wait_navigate_to_unread_messages = 2,
            wait_to_inject_message = 3,
            wait_to_send_message = 3,
            wait_to_stop = 1
        };

        private bool Close_models() {
            //TODO
            return true;
        }

        private bool Accept_chatting() {
            //TODO
            return true;
        }

        private bool Is_duplicate(mshtml.HTMLDocument doc)
        {
            string mess = Engine.getMessage();
            
            return doc.ToString().Contains(mess);

        }

        #endregion
    }
}
