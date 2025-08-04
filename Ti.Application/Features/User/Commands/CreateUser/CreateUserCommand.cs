using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ti.Application.Contracts.Persistance;
using Ti.Domain.Enums;
using Ti.Application.Helper;

namespace Ti.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateUserResponse();
            try
            {
                var entity = new Domain.Entities.User(request.FullName, request.Email, PasswordHasher.Hash(request.Password), request.Role);
                await _userRepository.AddAsync(entity);
                await _userRepository.SaveChangesAsync();
                response.Message = "کاربر با موفقیت ایجاد شد";
                response.Id = entity.Id;
            }
            catch (Exception)
            {
                response.Message = "در ایجاد پیام خطایی رخ داده است";
                response.Id = Guid.Empty;
                throw;
            }
            return response;
            

        }
    }
}
