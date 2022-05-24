using MuhammetAliDemir.TP.Net.Homework.Entity;
using System;

namespace MuhammetAliDemir.TP.Net.Homework.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomUserCheckAttribute : Attribute
    {
        private readonly string _userName;
        private readonly string _password;

        public CustomUserCheckAttribute(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        public bool ValidateUser(User user)
        {
            return true;
        }
    }
}