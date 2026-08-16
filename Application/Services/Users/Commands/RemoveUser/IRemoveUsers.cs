using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dr.Application.Services.Users.Commands.RemoveUser
{
    public interface IRemoveUsers
    {
        ResultDto Execute(requestRemoveUser request);
    }
    public class RemoveUserServices : IRemoveUsers
    {
        private readonly IDataBaseContext _context;
        public RemoveUserServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(requestRemoveUser request)
        {
            var user = _context.Users.Find(request.ID);
            if(user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            user.IsRemoved = true;
            user.RemovedTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };
        }
    }

    public class requestRemoveUser
    {
        public long ID { get; set; }
    }
}
