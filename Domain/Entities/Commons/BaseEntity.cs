namespace Dr.Domain.Entities.Commons
{
    public class BaseEntity<TKey>
    {
        public TKey ID { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemovedTime { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<long>
    {

    }
}
