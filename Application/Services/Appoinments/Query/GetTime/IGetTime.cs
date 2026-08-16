using Common.Dto;
using Dr.Application.Interfaces.DbContext;

namespace Dr.Application.Services.Appoinments.Query.GetTime
{
    public interface IGetTime
    {
        ResultDto<List<GetTimeDto>> Execute();
    }

    public class GetTimeServices : IGetTime
    {
        private readonly IDataBaseContext _context;
        public GetTimeServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetTimeDto>> Execute()
        {
            var result = _context.Times.ToList().Select(p => new GetTimeDto()
            {
                ID = p.ID,
                Hour = p.Hour,
                Minute = p.Minute,
                FullTime = $"  {p.Minute} :  {p.Hour}"

            }).ToList();
            return new ResultDto<List<GetTimeDto>>
            {
                Data = result,
            };

        }
    }

    public class GetTimeDto
    {
        public long ID { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }
        public string FullTime { get; set; }

    }
}
