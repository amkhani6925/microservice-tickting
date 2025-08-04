using Ti.Domain.Enums;

namespace Ti.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status{ get; set; }
        public Priority Priority { get; set; }
        public Guid CreatedByUserID { get; set; }
        public Guid? AssignedToUserId { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual User? AssignedToUser { get; set; }

        public Ticket(string title, string description, Priority priority, Guid createdByUserID)
        {
            Title = title;
            Description = description;
            Priority = priority;
            CreatedByUserID = createdByUserID;
            Status = TicketStatus.Open;
        }
        public Ticket()
        {
        }
    }  
    }
