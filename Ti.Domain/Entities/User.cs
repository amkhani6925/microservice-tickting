 using Ti.Domain.Enums;

namespace Ti.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role{ get; set; }


        public virtual ICollection<Ticket> CreatedTickets { get; set; } = new List<Ticket>();
        public virtual ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();

        public User(string fullName, string email, string password, Role role)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
        }

        public User()
        {
        }
    }
}