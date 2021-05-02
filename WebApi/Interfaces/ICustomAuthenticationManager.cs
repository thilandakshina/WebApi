using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICustomAuthenticationManager
    {
        string Authenticate(string username, string password);

        IDictionary<string, Tuple<string, string>> Tokens { get; }
    }
  
}
