using eUseControl.Domain.Entities.Vehicle;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISessionAdmin
    {
        ULoginResp AddCar(Vehicle car);
        void DeleteCar(string car);
        void DeleteReview(string message);
    }
}
