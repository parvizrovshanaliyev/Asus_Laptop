using AsusLaptop.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AsusLaptop.DAL
{
    public class AsusDbContext : IdentityDbContext<UserApp>
    {
        public AsusDbContext():base("AsusLaptop")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new UserAppDbContextInitializer());
            base.OnModelCreating(modelBuilder);
        }


        public class UserAppDbContextInitializer : DropCreateDatabaseIfModelChanges<AsusDbContext>
        {


            protected override void Seed(AsusDbContext context)
            {
                
                base.Seed(context);
            }
        }
    }
}