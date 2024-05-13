using System.Collections.Generic;
using System.Web;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Vehicle;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic
{
    public class SessionAdmin : AdminApi, ISessionAdmin
    {
        public ULoginResp AddCar(Vehicle car)
        {
            return AddNewCar(car);
        }
        public void DeleteCar(string carName)
        {
            DeleteCurrentCar(carName);
        }
        public void DeleteReview(string message)
        {
            DeleteCurrentReview(message);
        }
    }
}
