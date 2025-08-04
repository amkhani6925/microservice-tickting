using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ti.Application.Contracts.Persistance;
using Ti.Domain.Enums;

namespace Ti.Application.Features.Ticket.Commands.UpdateStatus
{
    public class UpdateStatusAndAssignCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid AssignedToUserId { get; set; }
        public TicketStatus  Status { get; set; }
        public Guid TicketId { get; set; }
    }
    public class UpdateStatusAndAssignHandler : IRequestHandler<UpdateStatusAndAssignCommand, bool>
    {
        private readonly ITicketRepository _ticketRepository;

        public UpdateStatusAndAssignHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<bool> Handle(UpdateStatusAndAssignCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ticket = await _ticketRepository.GetByIdAsync(request.Id);
                if (ticket == null) return false;
                ticket.AssignedToUserId = request.AssignedToUserId;
                ticket.Status = request.Status;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
