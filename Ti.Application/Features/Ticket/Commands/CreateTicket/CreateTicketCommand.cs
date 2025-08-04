using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ti.Application.Contracts.Persistance;
using Ti.Domain.Enums;

namespace Ti.Application.Features.Ticket.Commands.CreateTicket
{
    public class CreateTicketCommand : IRequest<CreateTicketResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Guid CreatedByUserID { get; set; }
    }
    public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, CreateTicketResponse>
    {
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<CreateTicketResponse> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateTicketResponse();
            try
            {
                var entity = new Domain.Entities.Ticket(request.Title, request.Description, request.Priority, request.CreatedByUserID);
                await _ticketRepository.AddAsync(entity);
                await _ticketRepository.SaveChangesAsync();
                response.Message = "تیکت با موفقیت ایجاد شد";
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
