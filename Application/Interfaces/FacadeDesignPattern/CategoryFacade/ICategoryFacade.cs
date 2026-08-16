using Dr.Application.Services.Categories.Commads.AddCategory;
using Dr.Application.Services.Categories.Queries.GetAllCategories;
using Dr.Application.Services.Categories.Queries.GetCategories;

namespace Dr.Application.Interfaces.FacadeDesignPattern.CategoryFacade
{
    public interface ICategoryFacade
    {
        public AddNewCategoryServices AddCategory { get; }
        public IGetCategories GetCategories { get; }
        public IGetAllCategories GetAllCategories { get; }
    }
}
