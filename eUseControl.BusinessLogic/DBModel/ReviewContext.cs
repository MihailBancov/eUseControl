using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Vehicle;

using eUseControl.Domain.Entities.Review;

namespace eUseControl.BusinessLogic.DBModel
{
    public class ReviewContext : DbContext
    {
        public ReviewContext() : base("name=eUseControl")
        {
        }

        public virtual DbSet<UserReview> CustomerReviews { get; set; }
    }
}
