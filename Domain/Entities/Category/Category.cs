using Dr.Domain.Entities.Commons;

namespace Dr.Domain.Entities.Category
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryID { get; set; }
        

        //نمایش زیر مجموعه ها
        public virtual ICollection<Category> ChildCategories { get; set; }


    }
}
