using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
                //var UserManager = new UserManager<UserApp>(new UserStore<UserApp>(context));
                //var RoleManager = new RoleManager<RoleApp>(new RoleStore<RoleApp>(context));
                //string name = "admin";
                //string password = "parviz123";
                //string test = "parvizra";

                ////Create Role Test and User Test
                //RoleManager.Create(new RoleApp(test));
                //UserManager.Create(new UserApp() { UserName = test });
                ////Create Role Admin if it does not exist
                //if (!RoleManager.RoleExists(name))
                //{
                //    var roleresult = RoleManager.Create(new RoleApp(name));
                //}

                ////Create User=Admin with password=123456
                //var user = new UserApp
                //{
                //    UserName = name
                //};
                //var adminresult = UserManager.Create(user, password);
                ////Add User Admin to Role Admin
                //if (adminresult.Succeeded)
                //{
                //    var result = UserManager.AddToRole(user.Id, name);
                //}
                base.Seed(context);
            }
        }
    }
}