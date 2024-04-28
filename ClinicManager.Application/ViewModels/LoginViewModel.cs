using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel(Guid id,string token, string role)
        { 
            Id = id;
            Token = token;
            Role = role;
        }
         
        public Guid Id { get; private set; }

        public string Token { get; private set; }

        public string Role { get; private set; }
    }
}
