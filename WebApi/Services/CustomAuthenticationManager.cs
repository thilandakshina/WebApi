using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class CustomAuthenticationManager:ICustomAuthenticationManager
    {
        private readonly IList<User> users = new List<User>
        {
            new User { Username= "test1", Password= "password1", Role = "Administrator" },
            new User { Username = "test2",Password= "password2", Role = "User" }
        };

        private readonly IDictionary<string, Tuple<string, string>> tokens =
            new Dictionary<string, Tuple<string, string>>();

        public IDictionary<string, Tuple<string, string>> Tokens => tokens;

        public string Authenticate(string username, string password)
        {
            if (!users.Any(u => u.Username == username && u.Password == password))
            {
                return null;
            }

            var token = Guid.NewGuid().ToString();

            tokens.Add(token, new Tuple<string, string>(username,
                users.First(u => u.Username == username && u.Password == password).Role));

            return token;
        }
    }
}
