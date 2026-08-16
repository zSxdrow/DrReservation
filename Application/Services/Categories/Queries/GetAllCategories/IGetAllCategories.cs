using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Dr.Application.Services.Categories.Queries.GetAllCategories
{
    public interface IGetAllCategories
    {
        ResultDto<List<AllCategoriesDto>> Excute();
    }

    public class GetAllCategoryServices : IGetAllCategories
    {
        private readonly IDataBaseContext _Context;
        public GetAllCategoryServices(IDataBaseContext context)
        {
                _Context = context;
        }
        public ResultDto<List<AllCategoriesDto>> Excute()
        {
            var Result = _Context.Category.Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryID !=  null)
                .ToList()
                .Select( p => new AllCategoriesDto
                {
                    CategoryID = p.ID,
                    CategoryName = $"{p.ParentCategory.CategoryName} - {p.CategoryName}",
                }).ToList();

            return new ResultDto<List<AllCategoriesDto>>
            {
                Data = Result,
                IsSuccess = true
            };
        }
    }

    public class AllCategoriesDto
    {
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
