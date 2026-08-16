using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using System;
using System.Linq;

namespace Dr.Application.Services.Appoinments.Command.IsVisited
{
    public interface IChangeVisitStatus
    {
        ResultDto Execute(long AppCode);
    }
    public class ChangeIsVisitedServices : IChangeVisitStatus
    {
        private readonly IDataBaseContext _context;
        public ChangeIsVisitedServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long AppCode)
        {
            var result = _context.Appointments.
             FirstOrDefault(x => x.AppoinmentCode == AppCode.ToString());
            if (result == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            var txt = result.IsVisited == true ? "مراجعه نکرد" : " با موفقیت ویزیت شد ";
            result.IsVisited = !result.IsVisited;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = $"کاربر {result.Name + result.lName} {txt} "   
            };
        }
    }
}
