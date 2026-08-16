using Dr.Application.Services.Appoinments.Command.AddAppoinment;
using Dr.Application.Services.Appoinments.Command.IsVisited;
using Dr.Application.Services.Appoinments.Query.FindAppoinment;
using Dr.Application.Services.Appoinments.Query.GetAppoinment;
//using Dr.Application.Services.Appoinments.Query.GetDate;
using Dr.Application.Services.Appoinments.Query.GetInsurance;
using Dr.Application.Services.Appoinments.Query.GetServices;
using Dr.Application.Services.Appoinments.Query.GetTime;

namespace Dr.Application.Interfaces.FacadeDesignPattern.AppoinmentFacade;

public interface IAppoinmentFacade
{
    public AddNewAppoinmentServices AddAppoinment { get;}
    public IGetInsurances GetInsurances { get;}
    public IGetServices GetServices { get;}
    //public iget GetDate { get;}
    public IGetTime GetTime { get;}
    public IGetAppoinment GetAppoinment { get;}
    public ChangeIsVisitedServices IsVisited { get;}
    public IGetAppoinmentByTC GetAppoinmentByTC { get;}
    


}
