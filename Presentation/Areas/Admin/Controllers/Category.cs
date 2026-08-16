using Dr.Application.Interfaces.FacadeDesignPattern.CategoryFacade;
using Dr.Application.Services.Categories.Commads.AddCategory;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Category : Controller
    {
        private ICategoryFacade _categoryFacade;
        public Category(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }
        public IActionResult Index(long? ParentID)
        {
            return View(_categoryFacade.GetCategories.Execute(ParentID).Data);
        }
        [HttpGet]
        public IActionResult AddNewCategory(long? ParentID)
        {
         ViewBag.ParentID = ParentID;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCategory (long? ParentID , string CategoryName)
        {
            var result = _categoryFacade.AddCategory.Execute(new RequestAddCategory
            {
                ParentID = ParentID,
                CategoryName = CategoryName,
            });
            return Json(result);
        }
    }
}
