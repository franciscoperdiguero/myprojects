using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Master_Engine
{
    public static class Engine
    {
        private static string username;
        private static string password = "ssssss";
        private static string message;

        public static bool setUsername(string usr) {
            username = usr;
            return true;
        }

        public static string getUsername() {
            return username;
        }


        public static bool setMessage(string msg)
        {
            message = msg;
            return true;
        }

        public static string getMessage()
        {
            return message;
        }

        //public static bool setPassword(string pass)
        //{
        //    password = pass;
        //    return true;
        //}

        public static string getPassword()
        {
            return password;
        }

        public static void Suppress_scripts(WebBrowser the_browser)
        {
            dynamic instance = the_browser.GetType().InvokeMember(
                "ActiveXInstance",
                (BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Instance),
                null, the_browser, new object[] { });
            instance.Silent = true;
        }

        public static int To_Int(this Enum target) {
            return Convert.ToInt32(target);
        }
    }
}
