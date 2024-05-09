using CarRental.Domain.Entities.Car;
using CarRental.Domain.Entities.Review;
using CarRental.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarRental.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResp UserLogin(ULoginData data);
        ULoginResp UserRegistration(ULoginData data);
        HttpCookie GenCookie(string loginCredential);
        UserMinimal GetUserByCookie(string apiCookieValue);
        List<Car> GetCars();
        List<UserReview> GetReviews();
        void AddReview(UserReview review);
    }
}
