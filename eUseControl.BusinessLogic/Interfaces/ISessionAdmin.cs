using CarRental.Domain.Entities.Car;
using CarRental.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarRental.BusinessLogic.Interfaces
{
    public interface ISessionAdmin
    {
        ULoginResp AddCar(Car car);
        void DeleteCar(string car);
        void DeleteReview(string message);
    }
}
