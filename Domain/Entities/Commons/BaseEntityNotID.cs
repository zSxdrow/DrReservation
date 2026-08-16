namespace Dr.Domain.Entities.Commons
{
    public class BaseEntityNotID
    {
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }

    }
}
