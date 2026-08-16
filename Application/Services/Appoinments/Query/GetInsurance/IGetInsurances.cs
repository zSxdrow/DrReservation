using Common.Dto;
using Dr.Application.Interfaces.DbContext;

namespace Dr.Application.Services.Appoinments.Query.GetInsurance
{
    public interface IGetInsurances
    {
        ResultDto<List<ResultGetInsurances>> Execute();
    }
    public class GetInsuranceServices : IGetInsurances
    {
        private readonly IDataBaseContext _context;
        public GetInsuranceServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<ResultGetInsurances>> Execute()
        {
            var result = _context.Insurances.ToList().Select(p => new ResultGetInsurances
            {
                ID = p.ID,
                Name = p.Name,
            }).ToList();
            return new ResultDto<List<ResultGetInsurances>>
            {
                Data = result,
            };
        }
    }

    public class ResultGetInsurances
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }
}
