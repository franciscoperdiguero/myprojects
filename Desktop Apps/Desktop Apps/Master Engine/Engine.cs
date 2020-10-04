using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_Engine
{
    public static class Engine
    {
        private static string username;
        private static string password;
        private static string message;

        public static bool setUsername(string usr) {
            username = usr;
            return true;
        }

        public static string getUsername() {
            return username;
        }

        public static bool setPassword(string pass)
        {
            password = pass;
            return true;
        }

        public static string getPassword()
        {
            return password;
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


    }
}
