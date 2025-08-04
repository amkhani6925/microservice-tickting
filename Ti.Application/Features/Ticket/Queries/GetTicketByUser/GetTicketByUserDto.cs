using Ti.Domain.Enums;

namespace Ti.Application.Features.Ticket.Queries.GetTicketByUser
{
    public class GetTicketByUserDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public Priority Priority { get; set; }
        public Guid CreatedByUserID { get; set; }
        public Guid? AssignedToUserId { get; set; }

    }
}
