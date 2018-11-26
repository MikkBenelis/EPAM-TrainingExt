using System;
using System.Text.RegularExpressions;

namespace No1.Solution
{
    public static class CustomValidator
    {
        public static (bool, string) Validate(string password)
        {
            // check if password is null
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            // check if password is empty
            if (password == string.Empty)
                return (false, "password is empty");

            // check if length more than 5 chars 
            if (password.Length <= 5)
                return (false, $"{password} length too short");

            // check if length more than 15 chars
            if (password.Length >= 15)
                return (false, $"{password} length too long");

            // check if password contains admin word
            if (password.Contains("admin"))
                return (false, $"{password} can't contain admin word");

            // check for available symbols
            var regex = new Regex("^[0-9A-Za-z]+$");
            if (!regex.IsMatch(password))
                return (false, $"{password} contains unavailable symbols");

            return (true, string.Empty);
        }
    }
}
