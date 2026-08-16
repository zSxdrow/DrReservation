using Dr.Domain.Entities.Commons;
using Dr.Domain.Entities.User;
using Dr.Domain.Entities.Users;



namespace Dr.Domain.Entities.Users
{
    public class UserInRole : BaseEntity
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public long RoleID { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
