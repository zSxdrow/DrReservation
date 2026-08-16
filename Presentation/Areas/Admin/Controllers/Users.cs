using Dr.Application.Interfaces.FacadeDesignPattern.UsersFacade;
using Dr.Application.Services.Users.Commands.EditUsers;
using Dr.Application.Services.Users.Commands.RegisterUser;
using Dr.Application.Services.Users.Commands.RemoveUser;
using Dr.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Users : Controller
    {
        private readonly IUsersFacade _usersFacade;
        public Users(IUsersFacade usersFacade)
        {
            _usersFacade = usersFacade;
        }

        public IActionResult Index(string SearchKEY , int page = 1)
        {
            return View(_usersFacade.GetUsers.Execute(new RequestGetUsersDto
            {
                SearchKey = SearchKEY,
                Page = page
            })); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_usersFacade.GetRoles.Execute().Data, "ID", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(string UserName , string Name , string lName , string Password, string RePassword , string Phone , long RoleID)
        {
            var result = _usersFacade.RegisterUsers.Execute(new RequestRegisterUserDto
            {
                UserName = UserName,
                Name = Name,
                lName = lName,
                Password = Password,
                RePassword = RePassword,
                Phone = Phone,
                Role = new List<RolesInRegisterUser> { new RolesInRegisterUser { RoleID = RoleID } }
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Edit(long UserID , string Name , string lName)
        {
            var result = _usersFacade.EditUsers.Execute(new RequestEditUser
            { 
            ID = UserID,
            Name = Name,
            lName = lName
            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult Remove(long UserID)
        {
            var result = _usersFacade.RemoveUsers.Execute(new requestRemoveUser
            {
                ID = UserID
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult UserSatusChange(long UserID)
        {
            var result = _usersFacade.UserStatus.Execute(UserID);
            return Json(result);
        }
    }
}
