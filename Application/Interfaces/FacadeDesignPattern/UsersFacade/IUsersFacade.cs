using Dr.Application.Services.Users.Commands.EditUsers;
using Dr.Application.Services.Users.Commands.RegisterUser;
using Dr.Application.Services.Users.Commands.RemoveUser;
using Dr.Application.Services.Users.Commands.UserLogins;
using Dr.Application.Services.Users.Commands.UserStatusChange;
using Dr.Application.Services.Users.Queries.GetRoles;
using Dr.Application.Services.Users.Queries.GetUsers;

namespace Dr.Application.Interfaces.FacadeDesignPattern.UsersFacade
{
    public interface IUsersFacade
    {
        public IGetRoles GetRoles { get;}
        public IGetUsers GetUsers { get;}
        public RegisterUserServices RegisterUsers { get; }
        public EditUserServices EditUsers { get; }
        public RemoveUserServices RemoveUsers { get; }
        public UserStatusChangeServices UserStatus { get; }
        public UserLoginServices UserLogin { get; }

    }
}
