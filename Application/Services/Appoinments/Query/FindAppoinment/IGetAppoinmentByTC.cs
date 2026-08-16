using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Dr.Application.Services.Appoinments.Query.FindAppoinment
{
    public interface IGetAppoinmentByTC
    {
        ResultDto<ResultGetAppByTC> Execute(string TCode);
    }

    public class ResultGetAppByTC
    {
        public string Name { get; set; }
        public string lName { get; set; }
        public string NationalCode { get; set; }
        public string Insurance { get; set; }
        public string Service { get; set; }
        public string IsVisited { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
    }

    public class GetAppoinmentByTCServices : IGetAppoinmentByTC
    {
        private readonly IDataBaseContext _context;
        public GetAppoinmentByTCServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultGetAppByTC> Execute(string TCode)
        {
            var Appoinment = _context.Appointments
                .Include(p => p.Service)
                .Include(p => p.Insurance)
                .Include(p => p.Calender)
                .Include(p => p.Time)
                .FirstOrDefault(p => p.TrackingCode.Contains(TCode));
            if (Appoinment == null)
            {
                return new ResultDto<ResultGetAppByTC>
                {
                    IsSuccess = false,
                    Message = "نوبتی یافت نشد!"
                };
            }

            var result = new ResultGetAppByTC
            {
                Name = Appoinment.Name,
                lName = Appoinment.lName,
                NationalCode = Appoinment.NationalCode,
                Date = $"{Appoinment.Calender.Date.Year}/{Appoinment.Calender.Date.Month}/{Appoinment.Calender.Date.Day}",
                Insurance = Appoinment.Insurance.Name,
                Service = Appoinment.Service.Name,
                Time = $" {Appoinment.Time.Hour} :{Appoinment.Time.Minute} ",
                IsVisited = Appoinment.IsVisited == true ? "مراجعه کرده است" : "مراجعه نشده است",
            };

            return new ResultDto<ResultGetAppByTC>
            {
                Data = result,
                IsSuccess = true,
                Message = "نوبت یافت شد"
            };  
        }


    }
}
