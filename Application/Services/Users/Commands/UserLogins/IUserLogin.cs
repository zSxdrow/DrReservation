using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Dr.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Dr.Application.Services.Users.Commands.UserLogins
{
    public interface IUserLogin
    {
        ResultDto<ResultUserLogin> Execute(RequestUserLogin request);
    }
    public class UserLoginServices : IUserLogin
    {
        private readonly IDataBaseContext _context;
        public UserLoginServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultUserLogin> Execute(RequestUserLogin request)
        {
            if (string.IsNullOrWhiteSpace(request.UserName))
            {
                return new ResultDto<ResultUserLogin>
                {
                    IsSuccess = false,
                    Message = "لطفا نام کاربری خود را وارد نمایید"
                };

            }
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return new ResultDto<ResultUserLogin>
                {
                    IsSuccess = false,
                    Message = "لطفا رمز عبور خود را وارد نمایید"
                };

            }
            var User = _context.Users.Include(p => p.UserInRole)
                 .ThenInclude(p => p.Role)
                 .Where(x => x.UserName.Equals(request.UserName) && x.IsActive == true).FirstOrDefault();
            if (User == null)
            {
                return new ResultDto<ResultUserLogin>
                {
                    IsSuccess = false,
                    Message = "هیچ کاربری با این نام کاربری و رمز عبور در سایت ثبت نام نکرده است."
                };
            }
            bool IsTrue(string InputPassword, string MainPassword)
            {
                return InputPassword.Equals(MainPassword);
            }
            bool VerifyPassword = IsTrue(request.Password, User.Password);
            if (!VerifyPassword)
            {
                return new ResultDto<ResultUserLogin>
                {
                    Data = new ResultUserLogin { }
                    ,
                    IsSuccess = false
                    ,
                    Message = "رمز عبور اشتباه است"
                };
            }
            var Role = "";
            foreach (var item in User.UserInRole)
            {
                Role += $"{item.Role.RoleName}";
            }
            return new ResultDto<ResultUserLogin>
            {
                Data = new ResultUserLogin
                {
                    UserID = User.ID,
                    UserName = User.UserName,
                    Role = Role
                },
                IsSuccess = true,
                Message = $"خوش آمدید {User.Name}"

            };




        }
    }

    public class RequestUserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ResultUserLogin
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
