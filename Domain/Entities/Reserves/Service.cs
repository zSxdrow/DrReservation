using Dr.Domain.Entities.Commons;

namespace Dr.Domain.Entities.Reserves
{
    public class Service : BaseEntity
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }

}
