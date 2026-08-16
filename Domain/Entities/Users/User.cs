using Dr.Domain.Entities.Commons;
using Dr.Domain.Entities.User;

namespace Dr.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string lName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<UserInRole> UserInRole { get; set; }
    }
}
