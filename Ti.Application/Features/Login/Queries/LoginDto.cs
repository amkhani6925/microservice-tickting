using Ti.Domain.Enums;

namespace Ti.Application.Features.Login.Queries
{
    public class LoginDto
    {       
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
