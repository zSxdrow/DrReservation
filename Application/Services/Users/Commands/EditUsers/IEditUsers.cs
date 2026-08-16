using Common.Dto;
using Dr.Application.Interfaces.DbContext;

namespace Dr.Application.Services.Users.Commands.EditUsers
{
    public interface IEditUsers
    {
        ResultDto Execute(RequestEditUser request);


    }

    public class EditUserServices : IEditUsers
    {
        private readonly IDataBaseContext _context;
        public EditUserServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditUser request)
        {
            var user = _context.Users.Find(request.ID);
            if(user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "!کاربر پیدا نشد"
                };
            }
            user.Name = request.Name;
            user.lName = request.lName;
            user.UpdateTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت تصیحیح شد."
            };
        }
    }

    public class RequestEditUser
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string lName { get; set; }
    }
}
