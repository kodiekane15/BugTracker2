namespace BugTracker2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BugTracker2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WebGrease.Css.Extensions;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Project Manager"))
            {
                roleManager.Create(new IdentityRole { Name = "Project Manager" });
            }

            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole { Name = "Developer" });
            }

            if (!context.Roles.Any(r => r.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole { Name = "Submitter" });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "kodie@mailinator.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "kodie@mailinator.com",
                    UserName = "kodie@mailinator.com",
                    FirstName = "Kodie",
                    LastName = "Kane",
                    AvatarPath = "/Images/default_avatar.png",
                }, "Abc123.");

                var userId = userManager.FindByEmail("kodie@mailinator.com").Id;
                userManager.AddToRole(userId, "Admin");
            }

            if (!context.Users.Any(u => u.Email == "joslyn@mailinator.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "joslyn@mailinator.com",
                    UserName = "joslyn@mailinator.com",
                    FirstName = "Joslyn",
                    LastName = "Kane",
                    AvatarPath = "/Images/default_avatar.png",
                }, "Abc123.");

                var userId = userManager.FindByEmail("joslyn@mailinator.com").Id;
                userManager.AddToRole(userId, "Project Manager");
            }

            if (!context.Users.Any(u => u.Email == "Jay@mailinator.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "Jay@mailinator.com",
                    UserName = "Jay@mailinator.com",
                    FirstName = "Jay",
                    LastName = "Kane",
                    AvatarPath = "/Images/default_avatar.png",
                }, "Abc123.");

                var userId = userManager.FindByEmail("Jay@mailinator.com").Id;
                userManager.AddToRole(userId, "Developer");
            }

            if (!context.Users.Any(u => u.Email == "Heather@mailinator.com"))
            {
                userManager.Create(new ApplicationUser()
                {
                    Email = "Heather@mailinator.com",
                    UserName = "Heather@mailinator.com",
                    FirstName = "Heather",
                    LastName = "Kane",
                    AvatarPath = "/Images/default_avatar.png",
                }, "Abc123.");

                var userId = userManager.FindByEmail("Heather@mailinator.com").Id;
                userManager.AddToRole(userId, "Submitter");
            }

            //context.SaveChanges();
            //#region TicketType Seed
            //context.TicketTypes.AddOrUpdate
            //    (
            //    tt => tt.Name,
            //    new TicketType() { Name = "Software" },
            //    new TicketType() { Name = "Hardware" },
            //    new TicketType() { Name = "UI" },
            //    new TicketType() { Name = "Defect" },
            //    new TicketType() { Name = "Other" },
            //    new TicketType() { Name = "Feature Request" }
            //    );
            //#endregion
            //#region TicketPriority Seed
            //context.TicketPriorities.AddOrUpdate
            //    (
            //    tp => tp.Name,
            //    new TicketPriority() { Name = "Low" },
            //    new TicketPriority() { Name = "Medium" },
            //    new TicketPriority() { Name = "High" },
            //    new TicketPriority() { Name = "On Hold" }
            //    );
            //#endregion
            //#region TicketStatus Seed
            //context.TicketStatuses.AddOrUpdate
            //    (
            //    ts => ts.Name,
            //    new TicketStatus() { Name = "Open" },
            //    new TicketStatus() { Name = "Assigned" },
            //    new TicketStatus() { Name = "Resolved" },
            //    new TicketStatus() { Name = "Reopened" },
            //    new TicketStatus() { Name = "Archived" }
            //    );
            //#endregion


        }
    }
}
