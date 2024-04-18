using eUseControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
    public class CustomerReviews
    {
        public List<CustomerReview> Reviews { get; set; }

        public CustomerReviews()
        {
            Reviews = new List<CustomerReview>();
        }
    }
}