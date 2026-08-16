using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Dr.Application.Services.Appoinments.Query.GetInsurance;

namespace Dr.Application.Services.Appoinments.Query.GetServices
{
    public  interface IGetServices
    {
        ResultDto<List<GetServicesDto>> Execute();
    }

    public class GetServicesServices : IGetServices
    {
        private readonly IDataBaseContext _context;
        public GetServicesServices(IDataBaseContext context)
        {
          _context = context;  
        }
        public ResultDto<List<GetServicesDto>> Execute()
        {
            var result = _context.Services.ToList().Select(p => new GetServicesDto
            {
                ID = p.ID,
                Name = p.Name,
            }).ToList();

            return new ResultDto<List<GetServicesDto>>
            {
                Data =result,
                
            };


        }
    }

    public class GetServicesDto
    {
        public long ID { get; set; }
        public string Name { get; set; }

    }
}
