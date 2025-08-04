using MediatR;
using Ti.Application.Contracts.Persistance;

namespace Ti.Application.Features.Ticket.Queries.GetTicketCountByStatus
{
    public class GetTicketsCountByStatusHandler : IRequestHandler<GetTicketsCountByStatusQuery, int>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketsCountByStatusHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<int> Handle(GetTicketsCountByStatusQuery request, CancellationToken cancellationToken)
        {
            var query = await _ticketRepository.GetAsync(x => x.Status == request.Status);
            var result = query.ToList();
            return result.Count;
        }
    }
}
