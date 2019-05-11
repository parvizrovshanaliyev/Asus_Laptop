﻿using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
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
                

                //var passwordHasher = new PasswordHasher();
                //var user = new IdentityUser("Administrator")
                //{
                //    PasswordHash = passwordHasher.HashPassword("ra1234"),
                //    SecurityStamp = Guid.NewGuid().ToString()
                //};

                ////Step 2 Create and add the new Role.
                //var roleToChoose = new IdentityRole("Admin1");
                //context.Roles.Add(roleToChoose);

                ////Step 3 Create a role for a user
                //var role = new IdentityUserRole
                //{
                //    RoleId = roleToChoose.Id,
                //    UserId = user.Id
                //};

                ////Step 4 Add the role row and add the user to DB)
                //user.Roles.Add(role);
                //context.Users.Add(user);


                //var UserManager = new UserManager<UserApp>(new UserStore<UserApp>(context));
                //var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                //string name = "admin1";
                //string password = "parviz123";
                //string test = "parviz";

                ////Create Role Test and User Test
                //RoleManager.Create(new IdentityRole(test));
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
                //context.SaveChanges();
                base.Seed(context);
            }
        }
    }
}