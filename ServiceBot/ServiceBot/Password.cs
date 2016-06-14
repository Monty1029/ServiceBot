using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ServiceBot
{
    public class Password
    {
        string password;

        public Password()
        {
            
        }

        public void hashPassword()
        {
            var data = new byte[32];
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(data);
        }
    }
}