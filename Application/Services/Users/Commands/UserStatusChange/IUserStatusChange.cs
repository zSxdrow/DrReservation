using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dr.Application.Services.Users.Commands.UserStatusChange
{
    public interface IUserStatusChange
    {
        ResultDto Execute(long UserID);
    }
    public class UserStatusChangeServices : IUserStatusChange
    {
        private readonly IDataBaseContext _context;
        public UserStatusChangeServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long UserID)
        {
         var user = _context.Users.Find(UserID);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد!"
                };
            }
            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            var userStatus = user.IsActive == true ? "فعال" : "غیرفعال";
            return new ResultDto
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {userStatus} شد."
            };
        }
    }
}
