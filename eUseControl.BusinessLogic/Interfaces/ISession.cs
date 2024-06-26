﻿using eUseControl.Domain.Entities.Vehicle;
using eUseControl.Domain.Entities.Review;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResp UserLogin(ULoginData data);
        ULoginResp UserRegistration(ULoginData data);
        HttpCookie GenCookie(string loginCredential);
        UserMinimal GetUserByCookie(string apiCookieValue);
        List<Vehicle> GetCars();
        List<UserReview> GetReviews();
        void AddReview(UserReview review);
    }
}
