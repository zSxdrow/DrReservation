using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Dr.Domain.Entities.Category;



namespace Dr.Application.Services.Categories.Commads.AddCategory
{
    public interface IAddNewCategory
    {
        ResultDto Execute(RequestAddCategory request);
    }
    public class AddNewCategoryServices : IAddNewCategory
    {
        private readonly IDataBaseContext _context;
        public AddNewCategoryServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestAddCategory request)
        {
            if(string.IsNullOrWhiteSpace(request.CategoryName))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام دسته بندی را وارد نمایید"
                };
            }
            Category category = new()
            {
                CategoryName = request.CategoryName,
                ParentCategoryID = request.ParentID
            };
            _context.Category.Add(category);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد"
            };
        }
    }

    public class RequestAddCategory
    {
        public long? ParentID { get; set; }
        public string CategoryName { get; set; }
    }
}
