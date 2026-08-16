using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Dr.Application.Services.Categories.Queries.GetCategories
{
    public interface IGetCategories
    {
        ResultDto<List<CategoriesDto>> Execute(long? ParentID);
    }

    public class GetCategoryServices : IGetCategories
    {
        private readonly IDataBaseContext _context;
        public GetCategoryServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<CategoriesDto>> Execute(long? ParentID)
        {
            var result = _context.Category.Include(p => p.ParentCategory)
                .Include(p => p.ChildCategories)
                .Where(p => p.ParentCategoryID.Equals(ParentID)).Select(p => new CategoriesDto
                {
                    ID = p.ID,
                    Name = p.CategoryName,
                    Parent = p.ParentCategory != null ?
                    new ParentCategoryDto
                    {
                        ID = p.ParentCategory.ID,
                        Name = p.ParentCategory.CategoryName,
                    } : null,
                    HasChild = p.ChildCategories.Count() > 0 ? true : false
                }).ToList();
            return new ResultDto<List<CategoriesDto>>
            {
                Data = result,
            };


        }
    }

    public class CategoriesDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }
    }

    public class ParentCategoryDto
    {
        public long? ID { get; set; }
        public string Name { get; set; }
    }
}
