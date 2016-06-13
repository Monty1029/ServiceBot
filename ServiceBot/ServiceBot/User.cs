using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceBot
{
    public class User
    {
        private string name;
        private int id;
        private Avatar avatar;
        private Password password;

        public User(string name, int id, Avatar avatar, Password password)
        {
            this.name = name;
            this.id = id;
        }

        public string getName()
        {
            return name;
        }

        public int getId()
        {
            return id;
        }

        public Avatar getAvatar()
        {
            return avatar;
        }

        public void setAvatar()
        {

        }

        public Password getPassword()
        {
            return password;
        }

        public void setPassword()
        {

        }
    }
}