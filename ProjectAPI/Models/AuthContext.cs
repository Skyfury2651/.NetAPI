using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectAPI.Models
{
    public class AuthContext : IdentityDbContext<UserModel>
    {
        public AuthContext() : base("AuthContext")
        {

        }

        public virtual DbSet<Order> Orders { get; set; }
    }
}