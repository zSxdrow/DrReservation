using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Dr.Domain.Entities.Users;
using System.Text.RegularExpressions;

namespace Dr.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUsers
    {
        ResultDto<ResultRegisterUser> Execute(RequestRegisterUserDto request);
    }
    public class RegisterUserServices : IRegisterUsers
    {
        private readonly IDataBaseContext _context;
        public RegisterUserServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUser> Execute(RequestRegisterUserDto request)
        {
            try
            {
                //if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.lName)
                //    || string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password)
                //    || string.IsNullOrWhiteSpace(request.RePassword) || string.IsNullOrWhiteSpace(request.Phone))
                //{
                //    return new ResultDto<ResultRegisterUser>
                //    {
                //        Data = new ResultRegisterUser
                //        {
                //            UserID = 0
                //        },
                //        IsSuccess = false,
                //        Message = "لطفا تمامی موارد را به درستی وارد نمایید"

                //    };
                //}
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return new ResultDto<ResultRegisterUser>
                    {
                        Data = new ResultRegisterUser { UserID = 0 },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.lName))
                {
                    return new ResultDto<ResultRegisterUser>
                    {
                        Data = new ResultRegisterUser { UserID = 0 },
                        IsSuccess = false,
                        Message = "لطفا نام خانوادگی را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.UserName))
                {
                    return new ResultDto<ResultRegisterUser>
                    {
                        Data = new ResultRegisterUser { UserID = 0 },
                        IsSuccess = false,
                        Message = "نام کاربری را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Phone))
                {
                    return new ResultDto<ResultRegisterUser>
                    {
                        Data = new ResultRegisterUser { UserID = 0 },
                        IsSuccess = false,
                        Message = "شماره تلفن خود را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRegisterUser>
                    {
                        Data = new ResultRegisterUser { UserID = 0 },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.RePassword))
                {
                    return new ResultDto<ResultRegisterUser>
                    {
                        Data = new ResultRegisterUser { UserID = 0 },
                        IsSuccess = false,
                        Message = "تکرار رمز عبور را وارد نمایید"
                    };
                }
                if (request.Password.Length < 8)
                {
                    return new ResultDto<ResultRegisterUser>
                    {
                        Data = new ResultRegisterUser { UserID = 0 },
                        IsSuccess = false,
                        Message = "رمز عبور  نمیتواند کمتر از 8 کاراکتر داشته باشد"
                    };
                }
                if (request.Password != request.RePassword)
                {
                    return new ResultDto<ResultRegisterUser>
                    {
                        Data = new ResultRegisterUser { UserID = 0 },
                        IsSuccess = false,
                        Message = "رمز عبور با تکرار آن مطابقت ندارد"
                    };
                }
                string userNameRGX = @"^[A-Za-z][A-Za-z0-9_]*[A-Za-z0-9]$";
                var Usernamematch = Regex.Match(request.UserName, userNameRGX, RegexOptions.IgnoreCase);
                if (!Usernamematch.Success)
                {
                    return new ResultDto<ResultRegisterUser>
                    {
                        Data = new ResultRegisterUser { UserID = 0 },
                        IsSuccess = false,
                        Message = "لطفا نام کاربری را به درستی وارد نمایید"
                    };
                }
                var Phonepattern = @"^09\d{9}$";
                var PhoneRGX = Regex.Match(request.Phone, Phonepattern, RegexOptions.IgnoreCase);
                if (!PhoneRGX.Success)
                {
                    return new ResultDto<ResultRegisterUser>
                    {
                        Data = new ResultRegisterUser { UserID = 0 },
                        IsSuccess = false,
                        Message = "لطفا شماره تلفن خود را به درستی وارد نمایید"
                    };
                }

                //create user

                User user = new()
                {
                    UserName = request.UserName,
                    Name = request.Name,
                    lName = request.lName,
                    Phone = request.Phone,
                    Password = request.Password,
                    RePassword = request.RePassword,

                };
                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach(var item in request.Role)
                {
                    var roles = _context.Roles.Find(item.RoleID);
                    userInRoles.Add(new UserInRole
                    {
                        Role = roles,
                        RoleID = roles.RoleID,
                        User = user,
                        UserID = user.ID,

                    });
                    user.UserInRole = userInRoles;
                }
                _context.Users.Add(user);
                _context.SaveChanges();

                return new ResultDto<ResultRegisterUser>
                {
                    Data = new ResultRegisterUser { UserID = user.ID },
                    IsSuccess = true,
                    Message = "کاربر با موفقیت ثبت نام شد"
                };

            }
            catch
            {
                return new ResultDto<ResultRegisterUser>
                {
                    Data = new ResultRegisterUser { UserID = 0 },
                    IsSuccess = false,
                    Message = "شماره تلفن وارد شده از قبل در سامانه ثبت شده است"
                };
            }
        }
    }

    public class RequestRegisterUserDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string lName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Phone { get; set; }
        public List<RolesInRegisterUser> Role { get; set; }



    }

    public class RolesInRegisterUser
    {
        public long RoleID { get; set; }
    }

    public class ResultRegisterUser
    {
        public long UserID { get; set; }
    }
}
