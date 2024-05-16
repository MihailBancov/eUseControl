using System.Web;
using System.Data.Entity;
using eUseControl.Domain.Entities.User;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace BusinessLogic.DBModel
{
    class UserContext : DbContext
    {
        public UserContext() :
            base("name=eUseControl") //connectionString name define in your web.config
        {
        }

        public virtual DbSet<UDbTable> Users { get; set; }
    }

}
