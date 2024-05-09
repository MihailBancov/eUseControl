using System.Collections.Generic;
using System.Web;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Car;
using eUseControl.Domain.Entities.Review;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        public ULoginResp UserLogin(ULoginData data)
        {
            return UserLoginAction(data);
        }
        public ULoginResp UserRegistration(ULoginData data)
        {
            return UserRegistrationAction(data);
        }
        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }
        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
        public List<Car> GetCars()
        {
            return Car();
        }
        public List<UserReview> GetReviews()
        {
            return Review();
        }

        public void AddReview(UserReview review)
        {
            NewReview(review);
        }
    }
}
