using System;
using System.Text.RegularExpressions;

namespace HORTI.CORE.CROSSCUTTING.VALUEOBJECT
{
    public sealed class PasswordObject
    {
        public PasswordObject(object passwordObject, Type passwordType = null)
        {
            PasswordType = passwordType ?? typeof(string);
            Password = passwordObject;
        }

        public object Password { get; private set; }
        public bool IsValid()
        {
            if (PasswordType == typeof(string))
                return ValidateStringPassword();

            return false;
        }

        private Type PasswordType { get; set; }

        private bool ValidateStringPassword()
        {
            if (string.IsNullOrEmpty(Password.ToString()))
                return false;

            return Regex.Match(@Password.ToString(), @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,25}$").Success;
        }
    }
}
