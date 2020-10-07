namespace BugTracker2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Runtime.InteropServices;
    using System.Web.Configuration;
    using Antlr.Runtime.Tree;
    using BugTracker2.Helpers;
    using BugTracker2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WebGrease.Css.Extensions;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private UserRoleHelper roleHelper = new UserRoleHelper();
        private ProjectHelper projectHelper = new ProjectHelper();
        Random random = new Random();
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

            #region Demo Users
            var demoPassword = WebConfigurationManager.AppSettings["DemoPassword"];

            List<string> firstName = new List<string>() { "Robbie", "Herman", "James", "Francis", "Gregory", "Todd", "Howard" };
            List<string> lastName = new List<string>() { "Dalton", "Smith", "Guy", "Page", "Plant", "Henry", "Tang" };

            if (!context.Users.Any(u => u.Email == "DemoAdmin@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoAdmin@mailinator.com",
                    Email = "DemoAdmin@mailinator.com",
                    FirstName = "Admin",
                    LastName = "Demo",
                    AvatarPath = "/Images/default_avatar.png"
                }, demoPassword);
                var userId = userManager.FindByEmail("DemoAdmin@mailinator.com").Id;
                userManager.AddToRole(userId, "Admin");
            }
            
            if (!context.Users.Any(u => u.Email == "DemoPM1@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoPM1@mailinator.com",
                    Email = "DemoPM1@mailinator.com",
                    FirstName = firstName[random.Next(firstName.Count)],
                    LastName =  lastName[random.Next(lastName.Count)],
                    AvatarPath = "/Images/default_avatar.png"
                }, demoPassword);
                var userId = userManager.FindByEmail("DemoPM1@mailinator.com").Id;
                userManager.AddToRole(userId, "Project Manager");
            }
            
            if (!context.Users.Any(u => u.Email == "DemoPM2@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoPM2@mailinator.com",
                    Email = "DemoPM2@mailinator.com",
                    FirstName = firstName[random.Next(firstName.Count)],
                    LastName = lastName[random.Next(lastName.Count)],
                    AvatarPath = "/Images/default_avatar.png"
                }, demoPassword);
                var userId = userManager.FindByEmail("DemoPM2@mailinator.com").Id;
                userManager.AddToRole(userId, "Project Manager");
            }
           
            if (!context.Users.Any(u => u.Email == "DemoDev1@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev1@mailinator.com",
                    Email = "DemoDev1@mailinator.com",
                    FirstName = firstName[random.Next(firstName.Count)],
                    LastName = lastName[random.Next(lastName.Count)],
                    AvatarPath = "/Images/default_avatar.png"
                }, demoPassword);
                var userId = userManager.FindByEmail("DemoDev1@mailinator.com").Id;
                userManager.AddToRole(userId, "Developer");
            }
            if (!context.Users.Any(u => u.Email == "DemoDev2@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev2@mailinator.com",
                    Email = "DemoDev2@mailinator.com",
                    FirstName = firstName[random.Next(firstName.Count)],
                    LastName = lastName[random.Next(lastName.Count)],
                    AvatarPath = "/Images/default_avatar.png"
                }, demoPassword);
                var userId = userManager.FindByEmail("DemoDev2@mailinator.com").Id;
                userManager.AddToRole(userId, "Developer");
            }
            if (!context.Users.Any(u => u.Email == "DemoSub1@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub1@mailinator.com",
                    Email = "DemoSub1@mailinator.com",
                    FirstName = firstName[random.Next(firstName.Count)],
                    LastName = lastName[random.Next(lastName.Count)],
                    AvatarPath = "/Images/default_avatar.png"
                }, demoPassword);
                var userId = userManager.FindByEmail("DemoSub1@mailinator.com").Id;
                userManager.AddToRole(userId, "Submitter");
            }
            if (!context.Users.Any(u => u.Email == "DemoSub2@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub2@mailinator.com",
                    Email = "DemoSub2@mailinator.com",
                    FirstName = firstName[random.Next(firstName.Count)],
                    LastName = lastName[random.Next(lastName.Count)],
                    AvatarPath = "/Images/default_avatar.png"
                }, demoPassword);
                var userId = userManager.FindByEmail("DemoSub2@mailinator.com").Id;
                userManager.AddToRole(userId, "Submitter");
            }
           #endregion

            context.SaveChanges();
            #region Project Seed
            context.Projects.AddOrUpdate
                (
                    p => p.ProjectName,
                    new Project() { ProjectName = "Seed 1", Created = DateTime.Now.AddDays(-60), IsArchived = true },
                    new Project() { ProjectName = "Seed 2", Created = DateTime.Now.AddDays(-45) },
                    new Project() { ProjectName = "Seed 3", Created = DateTime.Now.AddDays(-30) },
                    new Project() { ProjectName = "Seed 4", Created = DateTime.Now.AddDays(-15) },
                    new Project() { ProjectName = "Seed 5", Created = DateTime.Now.AddDays(-7) }
                );
            #endregion
            #region TicketType Seed
            context.TicketTypes.AddOrUpdate
                (
                tt => tt.Name,
                new TicketType() { Name = "Software" },
                new TicketType() { Name = "Hardware" },
                new TicketType() { Name = "UI" },
                new TicketType() { Name = "Defect" },
                new TicketType() { Name = "Other" },
                new TicketType() { Name = "Feature Request" }
                );
            #endregion
            #region TicketPriority Seed
            context.TicketPriorities.AddOrUpdate
                (
                tp => tp.Name,
                new TicketPriority() { Name = "Low" },
                new TicketPriority() { Name = "Medium" },
                new TicketPriority() { Name = "High" },
                new TicketPriority() { Name = "On Hold" }
                );
            #endregion
            #region TicketStatus Seed
            context.TicketStatuses.AddOrUpdate
                (
                ts => ts.Name,
                new TicketStatus() { Name = "Open" },
                new TicketStatus() { Name = "Assigned" },
                new TicketStatus() { Name = "Resolved" },
                new TicketStatus() { Name = "Reopened" },
                new TicketStatus() { Name = "Archived" }
                );
            #endregion
            context.SaveChanges();
            #region Ticket Seed
            List<Ticket> ticketList = new List<Ticket>();
            List<ApplicationUser> projectManagers = new List<ApplicationUser>();
            List<ApplicationUser> developers = new List<ApplicationUser>();
            List<ApplicationUser> submitters = new List<ApplicationUser>();
            projectManagers.AddRange(roleHelper.UsersInRole("Project Manager"));
            developers.AddRange(roleHelper.UsersInRole("Developer"));
            submitters.AddRange(roleHelper.UsersInRole("Submitter"));
            #region Assigning users to projects by Role
            foreach (var project in context.Projects)
            {
                
                // Admin Assignment
                foreach (var user in roleHelper.UsersInRole("Admin"))
                {
                    projectHelper.AddUserToProject(user.Id, project.Id);
                }
                
                //Project Manager Assignment
                projectHelper.AddUserToProject(projectManagers[random.Next(projectManagers.Count)].Id, project.Id);

                //Developer Assignment
                var firstDev = developers[random.Next(developers.Count)].Id;
                var secondDev = developers[random.Next(developers.Count)].Id;
                while (firstDev == secondDev)
                {
                    secondDev = developers[random.Next(developers.Count)].Id;
                }
                projectHelper.AddUserToProject(firstDev, project.Id);
                projectHelper.AddUserToProject(secondDev, project.Id);

                //Submitter Assignment
                var firstSub = submitters[random.Next(submitters.Count)].Id;
                var secondSub = submitters[random.Next(submitters.Count)].Id;
                while (firstSub == secondSub)
                {
                    secondSub = submitters[random.Next(submitters.Count)].Id;
                }
                projectHelper.AddUserToProject(firstSub, project.Id);
                projectHelper.AddUserToProject(secondSub, project.Id);
            };
            #endregion

            foreach (var project in context.Projects.ToList())
            {
                projectManagers = projectHelper.ListUsersOnProjectInRole(project.Id, "Project Manager");
                developers = projectHelper.ListUsersOnProjectInRole(project.Id, "Developer");
                submitters = projectHelper.ListUsersOnProjectInRole(project.Id, "Submitter");
                foreach (var type in context.TicketTypes.ToList())
                {
                    foreach (var status in context.TicketStatuses.ToList())
                    {
                        foreach (var priority in context.TicketPriorities.ToList())
                        {
                            var developerId = developers[random.Next(developers.Count)].Id;
                            if (status.Name == "Open")
                            {
                                developerId = null;
                            }
                            var resolved = false;
                            var archived = false;
                            if (status.Name == "Resolved")
                            {
                                resolved = true;
                            }
                            if (status.Name == "Archived" || project.IsArchived)
                            {
                                archived = true;
                            }
                            var newTicket = new Ticket()
                            {
                                ProjectId = project.Id,
                                TicketPriorityId = priority.Id,
                                TicketTypeId = type.Id,
                                TicketStatusId = status.Id,
                                SubmitterId = submitters[random.Next(submitters.Count)].Id,
                                DeveloperId = developerId,
                                Created = DateTime.Now,
                                IssueName = $"This is a Seeded Ticket",
                                IssueDescription = $"This is a description of a ticket of type {type.Name} on {project.ProjectName}",
                                IsArchived = archived,
                                IsResolved = resolved
                            };
                            ticketList.Add(newTicket);
                        }
                    }
                }
            }
            context.Tickets.AddRange(ticketList);
            context.SaveChanges();
            #endregion

        }
    }
}
