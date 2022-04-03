using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Learning.Models
{
    public class UserModel
    {
        public const int ID_ERROR = -1000;
        public const string NAME_ERROR = "NULL";
        public const int AGE_ERROR = -1000;
        public const long CPF_ERROR = 00000000000;
        public const string PASSWORD_ERROR = "NULL";

        public static readonly UserModel UserTemplateError = 
            new UserModel(ID_ERROR, NAME_ERROR, AGE_ERROR, CPF_ERROR, PASSWORD_ERROR);

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long CPF { get; set; }
        public string Password { get; set; }

        public UserModel(int _Id, string name, int age, long _CPF, string password)
        {
            Id = _Id;
            Name = name;
            Age = age;
            CPF = _CPF;
            Password = password;
        }

        // Default empty constructor, used for data template, allowing checking the fields if the data was not changed when the user registers.
        public UserModel()
        {
            Id = ID_ERROR;
            Name = NAME_ERROR;
            Age = AGE_ERROR;
            CPF = CPF_ERROR;
            Password = PASSWORD_ERROR;
        }

        public static bool IsUserValid(UserModel user)
        {
            return user.Id != ID_ERROR 
                && user.Name != NAME_ERROR
                && user.Age != AGE_ERROR
                && user.CPF != CPF_ERROR
                && user.Password != PASSWORD_ERROR;
        }

    }
}