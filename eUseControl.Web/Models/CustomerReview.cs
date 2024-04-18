using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Models
{
    public class CustomerReview
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public CustomerReview()
        {
            Name = null;
            Message = null;
        }
    }
}