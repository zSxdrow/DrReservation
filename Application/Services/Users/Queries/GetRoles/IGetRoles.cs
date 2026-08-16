using Common.Dto;
using Dr.Application.Interfaces.DbContext;

namespace Dr.Application.Services.Users.Queries.GetRoles
{
    public interface IGetRoles
    {
        ResultDto<List<RolesDto>> Execute();
    }

    public class GetRolesServices : IGetRoles
    {
        private readonly IDataBaseContext _context;
        public GetRolesServices(IDataBaseContext context)
        {
            _context = context; 
        }

        public ResultDto<List<RolesDto>> Execute()
        {
            var Roles = _context.Roles.ToList().Select(p => new RolesDto
            {
                ID = p.RoleID,
                Name = p.RoleName
            }).ToList();
            return new ResultDto<List<RolesDto>>
            {
                Data = Roles,
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class RolesDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }
}
