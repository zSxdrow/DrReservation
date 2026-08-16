using Common.Dto;
using Dr.Application.Interfaces.DbContext;
using Dr.Application.Interfaces.FacadeDesignPattern.AppoinmentFacade;
using Dr.Application.Services.Appoinments.Command.AddAppoinment;
using Dr.Application.Services.Appoinments.Command.IsVisited;
using Dr.Application.Services.Appoinments.Query.FindAppoinment;
using Dr.Application.Services.Appoinments.Query.GetAppoinment;
using Dr.Application.Services.Appoinments.Query.GetInsurance;
using Dr.Application.Services.Appoinments.Query.GetServices;
using Dr.Application.Services.Appoinments.Query.GetTime;
using System.Reflection.Metadata;

namespace Dr.Application.Services.Appoinments.Facade
{
    public class AppoinmentFacade : IAppoinmentFacade
    {
        private readonly IDataBaseContext _context;
        public AppoinmentFacade(IDataBaseContext context)
        {
            _context = context;
        }
        private AddNewAppoinmentServices _addAppoinment;
        public AddNewAppoinmentServices AddAppoinment
        {
            get { return _addAppoinment = _addAppoinment ?? new AddNewAppoinmentServices(_context); }
        }

        private IGetInsurances _getInsurances;
        public IGetInsurances GetInsurances
        {
            get
            {
                return _getInsurances = _getInsurances ?? new GetInsuranceServices(_context);
            }
        }
        private IGetServices _getServices;
        public IGetServices GetServices
        {
            get
            {
                return _getServices = _getServices ?? new GetServicesServices(_context);
            }
        }

        private IGetTime _getTimes;
        public IGetTime GetTime
        {
            get
            {
                return _getTimes = _getTimes ?? new GetTimeServices(_context);
            }
        }
        private IGetAppoinment _getAppoinment;
        public IGetAppoinment GetAppoinment
        {
            get
            {
                return _getAppoinment = _getAppoinment ?? new GetAppoinmentServices(_context);
            }
        }
        private ChangeIsVisitedServices _changeIsVisited;
        public ChangeIsVisitedServices IsVisited
        {
            get
            {
                return _changeIsVisited = _changeIsVisited ?? new ChangeIsVisitedServices(_context);
            }
        }

        private IGetAppoinmentByTC _getAppTC;
        public IGetAppoinmentByTC GetAppoinmentByTC
        {
            get
            {
                return _getAppTC = _getAppTC ?? new GetAppoinmentByTCServices(_context);
            }
        }
    }
}
