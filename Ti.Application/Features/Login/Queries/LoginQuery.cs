 using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ti.Domain.Enums;

namespace Ti.Application.Features.Login.Queries
{
    public class LoginQuery : IRequest<LoginDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
