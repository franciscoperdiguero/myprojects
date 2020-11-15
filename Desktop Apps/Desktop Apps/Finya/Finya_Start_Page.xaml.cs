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
using System.Windows.Threading;

namespace Finya
{
    /// <summary>
    /// Interaction logic for Finya_Start_Page.xaml
    /// </summary>
    /// 
    public partial class Finya_Start_Page : System.Windows.Controls.Page
    {
        #region useful variables
        readonly string logout_url = "https://www.finya.de/Auth/goodbye/?c=logout";
        readonly string google = "https://www.google.com";
        readonly string Finya_Login_Page = "https://www.finya.de/Auth/signin/";
        readonly string Finya_messages_url = "https://www.finya.de/Messages/mailbox/";
        readonly string Finya_message_select_by_id_url = "https://www.finya.de/Messages/thread/";
        readonly string className1 = "thread--unread thread--unread-recv";
        readonly string Finya_message_box = "msgContent";
        readonly string Finya_send_button = "btnSend";
        private static List<string> messageLinks = new List<string>();


        private string currentlink;
        DispatcherTimer dTimer;

        private static int stage=0;
        private static int wait=0;

        static bool pageonceloaded = false;
        #endregion

        #region initiation
        public Finya_Start_Page()
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
            Start_timer(Stages.logout_Finya, Waits.wait_for_logout_Finya);
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
                case (int)Stages.logout_Finya:
                    go_to_logout_Finya_tick();
                    break;
                case (int)Stages.go_to_google_page:
                    go_to_google_page_tick(); 
                    break;
                case (int)Stages.go_to_Login:
                    go_to_login_tick();
                    break;
                case (int)Stages.inject_credentials:
                    inject_credentials_tick();
                    break;
                case (int)Stages.go_to_Finya_messages:
                    go_to_Finya_messages_tick();
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

            void go_to_logout_Finya_tick() 
            {
                if (wait >= 0)
                {
                    status_Label.Content = "I'll go to Finya Logout in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        try_to_go_to_logout_Finya();
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

            void go_to_login_tick() {
                if (wait >= 0)
                {
                    status_Label.Content = "I'll go to direct login in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        try_to_go_to_login();
                    }
                }
            }

            void inject_credentials_tick() {
                if (wait >= 0)
                {
                    status_Label.Content = "I'll go to inject credentials in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        try_to_inject_credentials();
                    }
                }
            }

            void go_to_Finya_messages_tick()
            {
                if (wait >= 0)
                {
                    status_Label.Content = "I'll go to Finya messages in " + wait + " seconds";
                    wait--;
                }
                else
                {
                    if (Stop_timer())
                    {
                        try_to_go_to_Finya_messages();
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
                case (int)Stages.logout_Finya:
                    logout_Finya_is_loaded();
                    break;
                case (int)Stages.go_to_google_page:
                    go_to_google_page_is_loaded();
                    break;
                case (int)Stages.go_to_Login:
                    go_to_Login_is_loaded();
                    break;
                case (int)Stages.inject_credentials:
                    go_to_inject_credentials_is_loaded();
                    break;
                case (int)Stages.go_to_Finya_messages:
                    go_to_Finya_messages_is_loaded();
                    break;
                case (int)Stages.navigate_to_unread_messages:
                    navigate_to_unread_message_is_loaded();
                    break;
                default:                   
                    break;
            }

            void logout_Finya_is_loaded()
            {
                if (!pageonceloaded)
                {
                    if (Main_Web.Source.ToString().Contains("finya.de")) {
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
                        if (Start_timer(Stages.go_to_Login, Waits.wait_to_go_to_Login))
                        {
                            pageonceloaded = true;
                        }
                    }
                    else {
                        status_Label.Content = "Google page is not found";
                    }
                }
                
            }

            void go_to_Login_is_loaded()
            {
                if (!pageonceloaded)
                {
                    if (Main_Web.Source.ToString().Contains("finya") && Main_Web.Source.ToString().Contains("signin"))
                    {
                        status_Label.Content = "Finya login page loaded";
                        if (Start_timer(Stages.inject_credentials, Waits.wait_to_inject_credentials))
                        {
                            pageonceloaded = true;
                        }
                    }
                }
                else
                {
                    status_Label.Content = "Finya login page is not found";
                }
            }

            void go_to_inject_credentials_is_loaded()
            {
                if (!pageonceloaded)
                {
                    if (Main_Web.Source.ToString().Contains("finya.de") && Main_Web.Source.ToString().Contains("MyFinya"))
                    {
                        status_Label.Content = "Inject credentials done";
                        if (Start_timer(Stages.go_to_Finya_messages, Waits.wait_to_go_to_Finya_messages))
                        {
                            pageonceloaded = true;
                        }
                    }
                }
                else
                {
                    status_Label.Content = "Problem Injecting Credentials.";
                    Start_timer(Stages.stop_program, Waits.wait_to_stop);
                }
            }

            void go_to_Finya_messages_is_loaded()
            {
                if (!pageonceloaded)
                {
                    if (Main_Web.Source.ToString().Contains("finya") && Main_Web.Source.ToString().Contains("Messages"))
                    {
                        status_Label.Content = "Finya messages page loaded";
                        if (Start_timer(Stages.gather_messages, Waits.wait_to_gather_messages))
                        {
                            pageonceloaded = true;
                        }
                    }
                }
                else
                {
                    status_Label.Content = "Finya messages is not found";
                }
            }

            void navigate_to_unread_message_is_loaded()
            {
                if (!pageonceloaded)
                {
                    string current = currentlink.Split('=')[1]?.ToString();
                    if (Main_Web.Source.ToString().Contains("finya") && Main_Web.Source.ToString().Contains("Messages") && Main_Web.Source.ToString().Contains(current))
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
        private void try_to_go_to_logout_Finya()
        {
            Main_Web.Source = new Uri(logout_url);
        }

        private void try_to_go_to_google_page()
        {
            Main_Web.Source = new Uri(google);
        }

        private void try_to_go_to_login()
        {
            Main_Web.Source = new Uri(Finya_Login_Page);
        }

        private void try_to_inject_credentials() {

            #region to close model
            if (Close_models())
            {
                now_inject_credentials();
            }
            #endregion

            void now_inject_credentials() {
                mshtml.HTMLDocument doc = (mshtml.HTMLDocument)Main_Web.Document;
                var Raw_Input_List = doc.getElementsByTagName("input");
                var Input_list = Raw_Input_List.OfType<mshtml.HTMLInputElement>().ToList();

                Input_list.ForEach(inputs => {

                    string id = inputs.id;
                    string name = inputs.getAttribute("name");

                    Console.WriteLine(Engine.getUsername());

                    if (id != null)
                    {
                        if (id.Contains("fy-ident"))
                        {
                            inputs.click();
                            inputs.focus();
                            inputs.innerText = Engine.getUsername();
                        }
                        else if (id.Contains("fy-pwd"))
                        {
                            inputs.click();
                            inputs.focus();
                            inputs.innerText = Engine.getPassword();
                        }
                    }
                    else if (name != null) { 
                        if (name.Contains("buttonLogon"))
                        {
                            inputs.click();
                        }
                    }
                   
                });
            }
        }

        private void try_to_go_to_Finya_messages() {
            Main_Web.Source = new Uri(Finya_messages_url);
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
                var Raw_Person_List = doc.getElementsByTagName("div");
                var Person_list = Raw_Person_List.OfType<mshtml.HTMLDivElement>().ToList();
                if (Person_list != null && Person_list.Count() > 0)
                {

                    Person_list.ForEach(person =>
                    {
                        string classname = person.getAttribute("className");

                        if (classname != null)
                        {
                            if (classname.Contains(className1))
                            {
                                string identifier = person.getAttribute("data-dpid");
                                messageLinks.Add(Finya_message_select_by_id_url + identifier + "/?view=0");
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
            else
            {
                status_Label.Content = "There is no message to work on";
                Start_timer(Stages.stop_program, Waits.wait_to_stop);
            }
        }

        private void Try_to_inject_message()
        {
            mshtml.HTMLDocument doc = (mshtml.HTMLDocument)Main_Web.Document;

            #region to accept chatting
            if (Accept_chatting()) //CHECK IF THERE IS CAPTCHA
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
                        string ident = box.id;

                        if (ident != null)
                        {
                            if (ident.Equals(Finya_message_box))
                            {
                                box.click();
                                box.focus();
                                box.innerText = Engine.getMessage();
                            }
                        }

                    });
                }
                else
                {
                    status_Label.Content = "No input box found";
                }
            }
            status_Label.Content = "Message injected succesfully.";
            Start_timer(Stages.send_message, Waits.wait_to_send_message);
        }

        private void Try_to_send_message()
        {
            mshtml.HTMLDocument doc = (mshtml.HTMLDocument)Main_Web.Document;
            var Raw_Button_list = doc.getElementsByTagName("button");
            var Button_List = Raw_Button_list.OfType<mshtml.HTMLButtonElement>().ToList();

            if (Button_List != null && Button_List.Count() > 0)
            {
                Button_List.ForEach(btn =>
                {
                    string ident = btn.id;

                    if (ident != null)
                    {
                        if (ident.Equals(Finya_send_button))
                        {
                            btn.click();
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

        #region Helpers
        private enum Stages
        {
            logout_Finya = 1,
            go_to_google_page = 2,
            go_to_Login = 3,
            inject_credentials = 4,
            go_to_Finya_messages = 5,
            gather_messages = 6,
            navigate_to_unread_messages= 7,
            inject_message = 8,
            send_message = 9,
            stop_program = 10
        };

        private enum Waits
        {
            wait_for_logout_Finya = 1,
            wait_for_go_to_google_page = 3,
            wait_to_go_to_Login = 3,
            wait_to_inject_credentials = 3,
            wait_to_go_to_Finya_messages = 3,
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
