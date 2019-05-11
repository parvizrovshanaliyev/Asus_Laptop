namespace AsusLaptop.Migrations
{
    using AsusLaptop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<AsusLaptop.DAL.AsusDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AsusLaptop.DAL.AsusDbContext context)
        {

            context.Roles.AddOrUpdate(r => new { r.Name }, new RoleApp { Name = "admin" });

            context.Users.AddOrUpdate(u => new { u.Email, u.UserName },

               new Models.UserApp
               {

                   Email = "parviz@gmail.com",
                   UserName = "parvizra",
                   PasswordHash = Crypto.HashPassword("parviz123"),
                   SecurityStamp = Crypto.Hash(DateTime.Now.ToString("yyyyMMddHHmmssfff")),
                   
               });

            context.AspNetUserRoles.Add(new AspNetUserRole
            {
                UserId = "b9d3a126-e235-415c-9248-bc242b9ab992",
                RoleId = "fb7450e2-5b29-4828-851d-547d38ed19c6",
            });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
