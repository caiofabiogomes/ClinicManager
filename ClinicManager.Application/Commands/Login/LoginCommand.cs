using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Enums;
using MediatR;

namespace ClinicManager.Application.Commands.Login
{
    public class LoginCommand  : IRequest<Result<LoginViewModel>>
    {
        public LoginCommand(string email, string password, ERoleEnum role)
        {
            Email = email;
            Password = password;
            Role = role;
        }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public ERoleEnum Role { get; private set; }
    }
}
