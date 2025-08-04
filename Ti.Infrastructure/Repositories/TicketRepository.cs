using Dis.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ti.Application.Contracts.Persistance;
using Ti.Domain.Entities;

namespace Ti.Infrastructure.Repositories
{
    public class TicketRepository : RepositoryBase<Ticket> , ITicketRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TicketRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
