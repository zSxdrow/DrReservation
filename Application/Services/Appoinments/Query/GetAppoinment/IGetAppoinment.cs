using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Dr.Domain.Entities.Reserves;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Dr.Application.Services.Appoinments.Query.GetAppoinment
{
    public interface IGetAppoinment
    {
        ResultDto<List<ResultGetAppoinment>> Execute();
    }
    public class GetAppoinmentServices : IGetAppoinment
    {
        private readonly IDataBaseContext _context;
        public GetAppoinmentServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<ResultGetAppoinment>> Execute()
        {
            // روش 1: ابتدا بیا تمام Appointment ها را بگیر

            var appointments = _context.Appointments
             .Include(p => p.Calender)
             .Include(p => p.Time)
             .Include(p => p.Service)
             .Include(p => p.Insurance)
             .ToList().
             OrderBy(p => p.Calender.Date.Year)
             .ThenBy(p => p.Calender.Date.Month).
             ThenBy(p => p.Calender.Date.Day)
             .Select(p => new ResultGetAppoinment
             {

                 AppoinmentCode = p.AppoinmentCode,
                 IsVisited = p.IsVisited,
                 Name = p.Name,
                 lName = p.lName,
                 NationalCode = p.NationalCode,
                 Phone = p.Phone,
                 Service = p.Service.Name,
                 Insurance = p.Insurance.Name,
                 Date = $"{p.Calender.Date.Year}/{p.Calender.Date.Month}/{p.Calender.Date.Day}",
                 Time = $" {p.Time.Minute} : {p.Time.Hour} ",
             }).ToList();
            if (appointments == null || appointments.Count == 0)
            {
                return new ResultDto<List<ResultGetAppoinment>>
                {
                    Data = new List<ResultGetAppoinment>(),
                    IsSuccess = true,
                    Message = "هیچ نوبتی یافت نشد"
                };
            }


            return new ResultDto<List<ResultGetAppoinment>>
            {
                Data = appointments,
            };
        }
    }
    public class ResultGetAppoinment
    {
        public string Name { get; set; }
        public string lName { get; set; }
        public string NationalCode { get; set; }
        public string Phone { get; set; }
        public string AppoinmentCode { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string timeM { get; set; }
        public string timeH { get; set; }



        public string Insurance { get; set; }
        public string Service { get; set; }
        public bool IsVisited { get; set; }
    }
}