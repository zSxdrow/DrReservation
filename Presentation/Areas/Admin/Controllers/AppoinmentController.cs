using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Dr.Application.Interfaces.FacadeDesignPattern.AppoinmentFacade;
using Dr.Application.Services.Appoinments.Command;

using Dr.Domain.Entities.Reserves;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Presentation.Controllers
{
    [Area("Admin")]
    public class AppoinmentController : Controller
    {
        private readonly IDataBaseContext _context;
        private readonly IAppoinmentFacade _appoinmentFacade;
        public AppoinmentController(IAppoinmentFacade appoinmentFacade, IDataBaseContext context)
        {
            _appoinmentFacade = appoinmentFacade;
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {

            return View(_appoinmentFacade.GetAppoinment.Execute().Data);
        }

        public IActionResult Index2()
        {

            return View();
        }
        public IActionResult AddAppoinment()
        {
            ViewBag.Insurance = new SelectList(_appoinmentFacade.GetInsurances.Execute().Data, "ID", "Name");
            ViewBag.Services = new SelectList(_appoinmentFacade.GetServices.Execute().Data, "ID", "Name");
            ViewBag.Time = new SelectList(_appoinmentFacade.GetTime.Execute().Data, "ID", "FullTime");
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
        [HttpPost]
        public IActionResult IsVisited(long appCode)
        {
            return Json(_appoinmentFacade.IsVisited.Execute(appCode));
        }

        [HttpGet]
        public IActionResult GetAvailableTimes(int year, int month, int day)
        {
            var dateKey = $"{year}{month:D2}{day:D2}";
            var takenTimeIds = _context.Appointments
                .Where(a => a.Calender.Date.Year.ToString() == year.ToString()
                         && a.Calender.Date.Month.ToString() == month.ToString()
                         && a.Calender.Date.Day.ToString() == day.ToString())
                .Select(a => a.Time.ID)
                .ToList();

            var allTimes = _context.Times.ToList().Select(t => new
            {
                id = t.ID,
                label = $"{t.Hour}:{t.Minute}",
                isTaken = takenTimeIds.Contains(t.ID)
            });

            return Json(allTimes);
        }
    }
}
