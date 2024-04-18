using eUseControl.Models;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Models
{
    public class IndexData
    {
        public VehiclesData vehiclesData { get; set; }
        public CustomerReviews customerReviews { get; set; }

        public IndexData()
        {
            vehiclesData = new VehiclesData();
            customerReviews = new CustomerReviews();

        }
    }
}