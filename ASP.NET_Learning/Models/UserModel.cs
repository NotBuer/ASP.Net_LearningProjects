using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Learning.Models
{
    public class UserModel
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public long CPF { get; set; }
        public string Password { get; set; }

        public UserModel(string name, int age, long _CPF, string password)
        {
            Name = name;
            Age = age;
            CPF = _CPF;
            Password = password;
        }

        public UserModel()
        {
            Name = "NoName";
            Age = 0;
            CPF = 0;
            Password = "NoPassword";
        }

    }
}