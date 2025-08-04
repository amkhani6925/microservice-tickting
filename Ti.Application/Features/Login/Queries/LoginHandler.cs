 using MediatR;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using Ti.Application.Contracts.Persistance;
using Ti.Domain.Entities;
using Ti.Application.Helper;

namespace Ti.Application.Features.Login.Queries
{
    public class LoginHandler : IRequestHandler<LoginQuery, LoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public LoginHandler(IUserRepository userRepository, ITokenService tokenService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<LoginDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAsync(u => u.Email == request.UserName);
            var user = users.FirstOrDefault();

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }
            if (!PasswordHasher.Verify(request.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid password");
            }
            var token = await _tokenService.GenerateToken(user.Id, user.Email, user.Role.ToString(), cancellationToken);

            return new LoginDto
            {
                UserName = user.Email,
                Token = token,
                LoginTime = DateTime.UtcNow
            };
        }
    }
}