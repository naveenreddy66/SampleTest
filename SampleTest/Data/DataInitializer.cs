using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SampleTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleTest.Data
{
    public class DataInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {


            /*
             * Create an "Admin" Role
             * Create a test user, set their Country to Canada, date of birth to Jan 01 2000, user name and email to test@test.com and password to testing1234
             * Create two Property's, both owned by the test user, but one is for sale, set both countries to Canada
             * */




            ApplicationUser user1 = new ApplicationUser
            {
                Country = "Canada",
                DateOfBirth = new DateTime(2000, 1, 1),
                UserName = "testc@test.com",
                PasswordHash = "testc@test.com"
                };
                UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

                IdentityRole role1 = new IdentityRole { Name = "Admin" };
                RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

                roleManager.Create(role1);
                userManager.Create(user1, "testing1234");
                userManager.AddToRole(user1.Id, "Admin");

            Property p1 = new Property
               {  
                ID = 1,
                Address = "Lamabton County",
                City = " Sarn5ia",
                Country = "Canada",
                isForSale = true,
                Price = 250000,
                Owner = user1
                };
            Property p2 = new Property
            {
                ID = 12,
                Address = "Lamabton County",
                City = " Sarnia",
                Country = "Canada",
                isForSale = true,
                Price = 550000,
                Owner = user1
            };
            Property p3 = new Property
            {
                ID = 13,
                Address = "Main street",
                City = "London",
                Country = "Canada",
                isForSale = false,
                Price = 50000,
                Owner = user1
            };
                context.Properties.Add(p1);
                user1.Properties.Add(p1);
                context.Properties.Add(p2);
                user1.Properties.Add(p2);
                context.Properties.Add(p3);
                user1.Properties.Add(p3);



            base.Seed(context);
            }
           
        }
    }
