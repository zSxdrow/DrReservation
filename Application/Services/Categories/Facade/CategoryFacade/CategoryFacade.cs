using Dr.Application.Interfaces.DbContext;
using Dr.Application.Interfaces.FacadeDesignPattern.CategoryFacade;
using Dr.Application.Services.Categories.Commads.AddCategory;
using Dr.Application.Services.Categories.Queries.GetAllCategories;
using Dr.Application.Services.Categories.Queries.GetCategories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dr.Application.Services.Categories.Facade.CategoryFacade
{
    public class CategoryFacade : ICategoryFacade
    {
        private readonly IDataBaseContext _context;
        public CategoryFacade(IDataBaseContext context)
        {
            _context = context;
        }

        private AddNewCategoryServices _AddCategory;
        public AddNewCategoryServices AddCategory
        {
            get
            {
                return _AddCategory = _AddCategory ?? new AddNewCategoryServices(_context);
            }
        }

        private IGetCategories _getCategories;
        public IGetCategories GetCategories
        {
            get
            {
                return _getCategories = _getCategories ?? new GetCategoryServices(_context);
            }
        }
        private IGetAllCategories _getAllCategories;
        public IGetAllCategories GetAllCategories
        {
            get
            {
                return _getAllCategories = _getAllCategories ?? new GetAllCategoryServices(_context);
            }
        }
    }
}
