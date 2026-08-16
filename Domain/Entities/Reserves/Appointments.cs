using Dr.Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace Dr.Domain.Entities.Reserves
{
    public class Appointments : BaseEntity
    {
        public string Name { get; set; }
        public string lName { get; set; }
        public string NationalCode { get; set; }
        public string Phone { get; set; }

        public string AppoinmentCode { get; set; }

        public bool IsReserved { get; set; }
        public bool IsVisited { get; set; } = false;

        public long InsuranceID { get; set; }
        public long ServiceID { get; set; }
        public long CalenderID { get; set; }
        public long TimeID { get; set; }

        //ravabet
        public virtual Times Time { get; set; }
        public virtual CalenderD Calender { get; set; }


        public virtual Insurance Insurance { get; set; }
        public virtual Service Service { get; set; }

        [MaxLength(14)]
        public string TrackingCode { get; set; }
    }
}
