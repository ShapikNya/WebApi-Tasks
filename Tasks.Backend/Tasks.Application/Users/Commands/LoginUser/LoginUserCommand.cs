using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Users.Commands.LogingUsrt
{
    public class LoginUserCommand : IRequest<String>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
