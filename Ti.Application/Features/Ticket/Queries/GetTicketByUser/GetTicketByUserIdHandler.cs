using MediatR;
using Ti.Application.Contracts.Persistance;

namespace Ti.Application.Features.Ticket.Queries.GetTicketByUser
{
    public class GetTicketByUserIdHandler : IRequestHandler<GetTicketByUserIdQuery, List<GetTicketByUserDto>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketByUserIdHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<GetTicketByUserDto>> Handle(GetTicketByUserIdQuery request, CancellationToken cancellationToken)
        {
            var query =await _ticketRepository.GetAsync(x => x.CreatedByUserID == request.UserId);
            var ticket = query.ToList();
            if (ticket.Count ==0) return new List<GetTicketByUserDto>();

            return ticket.Select(x=>new GetTicketByUserDto
            {
                AssignedToUserId = x.AssignedToUserId,
                CreatedByUserID = x.CreatedByUserID,
                Description = x.Description,
                Priority = x.Priority,
                Status = x.Status,
                Title = x.Title
            }).ToList();
        }
    }
}
