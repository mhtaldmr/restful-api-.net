using MuhammetAliDemir.TP.Net.Homework.Entity;
using System;

namespace MuhammetAliDemir.TP.Net.Homework.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomUserCheckAttribute : Attribute
    {
        public readonly string _userName;
        public readonly string _password;

        public CustomUserCheckAttribute(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }
    }
}