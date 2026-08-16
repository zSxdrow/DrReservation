using Dr.Domain.Entities.Commons;
using System.Globalization;

namespace Dr.Domain.Entities.Reserves
{
    public class CalenderD : BaseEntity
    {
        public long ID { get; set; }
        public DateOnly Date { get; set; }
        public bool IsHoliday { get; set; }
        public string? Message { get; set; }

    }
}
