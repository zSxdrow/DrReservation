using Dr.Application.Interfaces.DbContext;
using Dr.Application.Interfaces.FacadeDesignPattern.AppoinmentFacade;
using Dr.Application.Services.Appoinments.Command;
using Dr.Domain.Entities.Reserves;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection.Emit;

namespace Presentation.Controllers
{
    public class Appoinment : Controller
    {
        private readonly IAppoinmentFacade _appoinmentFacade;
        private readonly IDataBaseContext _context;

        public Appoinment(IAppoinmentFacade appoinmentFacade, IDataBaseContext context)
        {
            _appoinmentFacade = appoinmentFacade;
            _context = context;
        }

        [HttpGet]
        public IActionResult AddAppoinment()
        {

            PersianCalendar pc = new();
            ViewBag.curYear = pc.GetYear(DateTime.Now);
            ViewBag.curMonth = pc.GetMonth(DateTime.Now);
            ViewBag.Year = pc.GetYear(DateTime.Now);
            ViewBag.Month = pc.GetMonth(DateTime.Now);
            ViewBag.Day = pc.GetDayOfMonth(DateTime.Now);
            ViewBag.Insurance = new SelectList(_appoinmentFacade.GetInsurances.Execute().Data, "ID", "Name");
            ViewBag.Services = new SelectList(_appoinmentFacade.GetServices.Execute().Data, "ID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddAppoinment(string Name, string lName, string NationalCode, string Phone,
            long DateID, long TimeID, long ServiceID, long InsuranceID)
        {
            var result = _appoinmentFacade.AddAppoinment.Execute(new RequestAddApponments
            {
                Name = Name,
                lName = lName,
                NationalCode = NationalCode,
                Phone = Phone,
                calenderID = DateID,
                ServiceID = ServiceID,
                TimeID = TimeID,
                InsuranceID = InsuranceID
            });
            return Json(result);
        }

        [HttpGet]
        public IActionResult GetAvailableTimes(int year, int month, int day)
        {
            var takenTimeIds = _context.Appointments
                .Include(a => a.Calender)
                .Include(a => a.Time)
                .Where(a => a.Calender.Date.Year == year
                         && a.Calender.Date.Month == month
                         && a.Calender.Date.Day == day)
                .Select(a => a.Time.ID)
                .ToList();

            var allTimes = _context.Times
                .ToList()
                .Select(t => new
                {
                    id = t.ID,
                    label = $"{t.Hour:D2}:{t.Minute:D2}",
                    isTaken = takenTimeIds.Contains(t.ID)
                });

            return Json(allTimes);
        }
        [HttpGet]
        public IActionResult GetValidDates()
        {
            var dates = _context.Calenders
                .ToList()
                .Select(d => new
                {
                    id = d.ID,
                    year = d.Date.Year,
                    month = d.Date.Month,
                    day = d.Date.Day
                })
                .ToList();

            return Json(dates);
        }


        [HttpGet]
        public IActionResult FindAppoinmentByCode()
        {
            return View(); // بدون پارامتر - جستجو از طریق AJAX انجام میشه
        }

        // اکشن جدید برای AJAX
        [HttpGet]
        public IActionResult GetAppByCode(string TCode)
        {
            if (string.IsNullOrWhiteSpace(TCode))
                return Json(new { isSuccess = false, message = "کد رهگیری را وارد کنید" });

            var result = _appoinmentFacade.GetAppoinmentByTC.Execute(TCode);

            if (!result.IsSuccess)
                return Json(new { isSuccess = false, message = result.Message });

            return Json(new { isSuccess = true, message = result.Message, data = result.Data });
        }

    }
}