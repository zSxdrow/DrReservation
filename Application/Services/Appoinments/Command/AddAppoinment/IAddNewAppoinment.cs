using Dr.Application.Interfaces.DbContext;
using Dr.Domain.Entities.Reserves;
using System.Linq;

namespace Dr.Application.Services.Appoinments.Command.AddAppoinment
{
    public interface IAddNewAppoinment
    {
        ResultAPDto Execute(RequestAddApponments request);
    }
    public class AddNewAppoinmentServices : IAddNewAppoinment
    {
        private readonly IDataBaseContext _Context;
        public AddNewAppoinmentServices(IDataBaseContext context)
        {
            _Context = context;
        }
        public ResultAPDto Execute(RequestAddApponments request)
        {
            try
            {

                if (request.NationalCode.Length > 10 || request.NationalCode.Length <= 0)
                    return new ResultAPDto
                    { 
                    IsSuccess = false,
                    Message = "کد ملی نمیتواند کمتر از 0 رقم و بیشتر از 10 رقم باشد!"
                    };
                //if (request.Phone.Length >= 0 || request.Phone.Length > 12)
                //    return new ResultAPDto
                //    {
                //        IsSuccess = false,
                //        Message = "شماره تلفن نمیتواند کمتر از 0 رقم و بیشتر از 10 رقم باشد!"
                //    };
                if (string.IsNullOrEmpty(request.Name))
                    return new ResultAPDto { IsSuccess = false, Message = "لطفا نام را وارد نمایید" };

                if (string.IsNullOrEmpty(request.lName))
                    return new ResultAPDto { IsSuccess = false, Message = "لطفا نام خانوادگی را وارد نمایید" };

                if (string.IsNullOrEmpty(request.NationalCode))
                    return new ResultAPDto { IsSuccess = false, Message = "لطفا کد ملی را وارد نمایید" };

                if (string.IsNullOrEmpty(request.Phone))
                    return new ResultAPDto { IsSuccess = false, Message = "لطفا شماره تلفن را وارد نمایید" };

                if (request.InsuranceID == 0)
                    return new ResultAPDto { IsSuccess = false, Message = "لطفا نوع بیمه را انتخاب کنید" };

                if (request.ServiceID == 0)
                    return new ResultAPDto { IsSuccess = false, Message = "لطفا نوع ویزیت را انتخاب کنید" };

                if (request.calenderID == 0)
                    return new ResultAPDto { IsSuccess = false, Message = "لطفا تاریخ مراجعه را انتخاب کنید" };

                if (request.TimeID == 0)
                    return new ResultAPDto { IsSuccess = false, Message = "لطفا ساعت مراجعه را انتخاب کنید" };

                // ← فقط چک میکنیم وجود داره یا نه
                if (!_Context.Insurances.Any(x => x.ID == request.InsuranceID))
                    return new ResultAPDto { IsSuccess = false, Message = "بیمه انتخابی معتبر نیست" };

                if (!_Context.Services.Any(x => x.ID == request.ServiceID))
                    return new ResultAPDto { IsSuccess = false, Message = "خدمت انتخابی معتبر نیست" };

                if (!_Context.Calenders.Any(x => x.ID == request.calenderID))
                    return new ResultAPDto { IsSuccess = false, Message = "تاریخ انتخابی معتبر نیست" };

                if (!_Context.Times.Any(x => x.ID == request.TimeID))
                    return new ResultAPDto { IsSuccess = false, Message = "زمان انتخابی معتبر نیست" };
                var date = _Context.Calenders.Find(request.calenderID);
                if(date.IsHoliday)
                {
                    return new ResultAPDto
                    { 
                    IsSuccess = false,
                    TrackingCode = "",
                    Message = "تاریخ انتخاب شده صحیح نمی باشد"
                    };

                }
                var time = _Context.Times.Find(request.TimeID);
                var trackingCode = GenerateAppointmentCode();
                var appCode = $"{date.Date.Year}{date.Date.Month}{date.Date.Day}{time.Hour}{time.Minute}";
                // ← فقط FK های ID رو ست میکنیم، نه navigation property ها
                Appointments appointment = new Appointments()
                {
                    Name = request.Name,
                    lName = request.lName,
                    NationalCode = request.NationalCode,
                    Phone = request.Phone,
                    InsuranceID = request.InsuranceID,
                    ServiceID = request.ServiceID,
                    CalenderID = request.calenderID,
                    TimeID = request.TimeID,
                    IsReserved = true,
                    TrackingCode = trackingCode,
                    AppoinmentCode = appCode,
                };

                _Context.Appointments.Add(appointment);
                _Context.SaveChanges();

                return new ResultAPDto
                {
                    IsSuccess = true,
                    Message = "نوبت با موفقیت ثبت شد",
                    TrackingCode = trackingCode
                };
            }
            catch (Exception ex)
            {
                return new ResultAPDto
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message,
                    TrackingCode = ""
                };
            }
        }

        public static string GenerateAppointmentCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var code = new char[12];

            for (int i = 0; i < 12; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }

            var raw = new string(code);

            // تبدیل به A3F7-9B1C-E8K2
            return $"{raw.Substring(0, 4)}-{raw.Substring(4, 4)}-{raw.Substring(8, 4)}";
        }
    }
}

public class RequestAddApponments
{
    public string Name { get; set; }
    public string lName { get; set; }
    public string NationalCode { get; set; }
    public string Phone { get; set; }

    public string AppoinmentCode { get; set; }
    public long calenderID { get; set; }
    public long TimeID { get; set; }
    public long ServiceID { get; set; }
    public long InsuranceID { get; set; }
}

public class ResultAPDto
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public string TrackingCode { get; set; }
}

