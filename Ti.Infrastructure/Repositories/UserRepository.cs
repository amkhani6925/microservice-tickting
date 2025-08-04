using Dis.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ti.Application.Contracts.Persistance;
using Dis.Infrastructure.Persistence;
using Ti.Domain.Entities;

namespace Ti.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
