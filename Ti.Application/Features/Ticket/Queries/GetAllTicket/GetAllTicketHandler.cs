using MediatR;
using Ti.Application.Contracts.Persistance;

namespace Ti.Application.Features.Ticket.Queries.GetAllTicket
{
    public class GetAllTicketHandler : IRequestHandler<GetAllTicketQuery, List<GetAllTicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetAllTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<GetAllTicketDto>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken)
        {
            var query = await _ticketRepository.GetAllAsync();
            var tickets = query.ToList();
            if(tickets.Count == 0) return new List<GetAllTicketDto>();

            return tickets.Select(x => new GetAllTicketDto
            {
                AssignedToUserId = x.AssignedToUserId,
                CreatedByUserID = x.CreatedByUserID,
                Description = x.Description,
                Priority = x.Priority,
                Status = x.Status,
                Title  = x.Title
            }).ToList();
        }
    }
}
