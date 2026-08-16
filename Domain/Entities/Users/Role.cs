using Dr.Domain.Entities.Commons;
using Dr.Domain.Entities.Users;

namespace Dr.Domain.Entities.User
{
    public class Role : BaseEntityNotID
    {
        public long RoleID { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserInRole> UserInRole { get; set; }
        
    }
}
