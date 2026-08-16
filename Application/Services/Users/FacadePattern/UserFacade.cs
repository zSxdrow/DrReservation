using Dr.Application.Interfaces.DbContext;
using Dr.Application.Interfaces.FacadeDesignPattern.UsersFacade;
using Dr.Application.Services.Users.Commands.EditUsers;
using Dr.Application.Services.Users.Commands.RegisterUser;
using Dr.Application.Services.Users.Commands.RemoveUser;
using Dr.Application.Services.Users.Commands.UserLogins;
using Dr.Application.Services.Users.Commands.UserStatusChange;
using Dr.Application.Services.Users.Queries.GetRoles;
using Dr.Application.Services.Users.Queries.GetUsers;

namespace Dr.Application.Services.Users.FacadePattern
{
    public class UserFacade : IUsersFacade
    {
        private readonly IDataBaseContext _context;
        public UserFacade(IDataBaseContext context)
        {
            _context = context; 
        }
        private IGetRoles _getRoles;
        public IGetRoles GetRoles
        {
            get
            {
                return _getRoles = _getRoles ?? new GetRolesServices(_context);
            }
        }

        private IGetUsers _getUsers;
        public IGetUsers GetUsers
        { 
            get
            {
                return _getUsers = _getUsers ?? new GetUserServices(_context);
            }
        }
        private RegisterUserServices _RegUsers;
        public RegisterUserServices RegisterUsers
        {
            get
            {
                return _RegUsers = _RegUsers ?? new RegisterUserServices(_context);
            }
        }
        private EditUserServices _EditUsers;
        public EditUserServices EditUsers
        {
            get
            {
                return _EditUsers = _EditUsers ?? new EditUserServices(_context);
            }
        }

        private RemoveUserServices _RemoveUsers;
        public RemoveUserServices RemoveUsers
        {
            get
            {
                return _RemoveUsers = _RemoveUsers ?? new RemoveUserServices(_context);
            }
        }

        private UserStatusChangeServices _UserStatusChange;
        public UserStatusChangeServices UserStatus
        {
            get
            {
                return _UserStatusChange = _UserStatusChange ?? new UserStatusChangeServices(_context);
            }
        }

        private UserLoginServices _UserLogin;
        public UserLoginServices UserLogin
        {
            get
            {
                return _UserLogin = _UserLogin ?? new UserLoginServices(_context);
            }
        }
    }
}
