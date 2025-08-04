using Dis.Application.Contracts.Persistance;
using Ti.Domain.Entities;

namespace Ti.Application.Contracts.Persistance
{
    public interface IUserRepository : IAsyncRepository<User>
    {

    }
}