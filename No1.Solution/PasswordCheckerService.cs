using System;
using System.Linq;

namespace No1.Solution
{
    public class PasswordCheckerService
    {
        private readonly IRepository repository = null;

        public PasswordCheckerService(IRepository repository)
        {
            if (repository == null)
                throw new ArgumentException($"{repository} is null arg");
            else
                this.repository = repository;
        }
        
        public (bool, string) VerifyPassword(string password, Func<string, (bool, string)> validator = null)
        {
            if (validator == null)
            {
                // check if password is null
                if (password == null)
                    throw new ArgumentException($"{password} is null arg");

                // check if password is empty
                if (password == string.Empty)
                    return (false, "password is empty");

                // check if length more than 7 chars 
                if (password.Length <= 7)
                    return (false, $"{password} length too short");

                // check if length more than 10 chars
                if (password.Length >= 10)
                    return (false, $"{password} length too long");

                // check if password contains at least one alphabetical character 
                if (!password.Any(char.IsLetter))
                    return (false, $"{password} hasn't alphanumerical chars");

                // check if password contains at least one digit character 
                if (!password.Any(char.IsNumber))
                    return (false, $"{password} hasn't digits");
            } else
            {
                // check password using custom validator
                (bool, string) result = validator(password);
                if (!result.Item1)
                    return result;
            }

            // create user
            repository.Create(password);

            return (true, "Password is Ok. User was created");
        }
    }
}
