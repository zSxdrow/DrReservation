using Common.Clases;
using Common.Dto;
using Dr.Application.Interfaces.DbContext;

namespace Dr.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsers
    {
        ResultGetUsersDto Execute(RequestGetUsersDto request);
    }

    public class GetUserServices : IGetUsers
    {
        private readonly IDataBaseContext _context;
        public GetUserServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultGetUsersDto Execute(RequestGetUsersDto request)
        {
            var users = _context.Users.AsQueryable();
            if(!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.Name.Contains(request.SearchKey) || p.lName.Contains(request.SearchKey) || p.UserName.Contains(request.SearchKey));
            }
            int RowsCount = 0;
            var result = users.Select(p => new GetUsersDto
            {
                ID = p.ID,
                Name = p.Name,
                lName = p.lName,
                IsActive = p.IsActive,
                Phone = p.Phone,
                UserName = p.UserName


            }).ToPaged(request.Page, 20, out RowsCount).ToList();
            return new ResultGetUsersDto
            {
                RowsCount = RowsCount,
                Users = result
            };
        }
    }


    public class ResultGetUsersDto
    {
        public List<GetUsersDto> Users { get; set; }
        public int RowsCount { get; set; }
    }

    public class GetUsersDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string lName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } = true;
        //public string Role { get; set; }
    }

    public class RequestGetUsersDto
    {
        public string SearchKey { get; set; }
        public int Page { get; set; }

    }



}
