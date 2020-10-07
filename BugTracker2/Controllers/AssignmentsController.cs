using BugTracker2.Helpers;
using BugTracker2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker2.Controllers
{
    public class AssignmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserHelper userHelper = new UserHelper();
        private UserRoleHelper roleHelper = new UserRoleHelper();
        private ProjectHelper projectHelper = new ProjectHelper();

        #region Role Assignment
        [HttpGet]
        [Authorize(Roles = "Admin, Project Manager")]
        public ActionResult ManageRoles()
        {
            ViewBag.UserIds = new MultiSelectList(db.Users, "Id", "FullName");
            ViewBag.RoleName = new SelectList(db.Roles.Where(r => r.Name != "Admin"), "Name", "Name");

            return View(db.Users.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageRoles(List<string> userIds, string roleName)
        {
            //Step:1 If anyone was selected, remove them from all of their roles.

            //If people were selected, Spin through them and strip them of their roles 
            foreach (var userId in userIds)
            {
                //Determine if this user occupies a role.
                foreach (var role in roleHelper.ListUserRoles(userId).ToList())
                {
                    roleHelper.RemoveUserFromRole(userId, role);
                }
                //If a role was seleceted add the user back to it.
                //Step 2: If a role was chosen, Add each person to that role.
                if (!string.IsNullOrEmpty(roleName))
                {
                    roleHelper.AddUserToRole(userId, roleName);
                }
            }
            return RedirectToAction("ManageRoles");
        }
        #endregion

        #region Project Assignment
        [Authorize(Roles = "Admin, Project Manager")]
        public ActionResult ManageProjectUsers()
        {
            //We want 2 list boxes in the View, therefore I want to load up 2 multiSelecLists
            ViewBag.userIds = new MultiSelectList(db.Users, "Id", "FullName");
            ViewBag.projectIds = new MultiSelectList(db.Projects, "Id", "ProjectName");
            return View(db.Users.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageProjectUsers(List<string> userIds, List<int> projectIds, bool assignRemove)
        {
            //Case 1: No Users and No Projects
            if (userIds == null || projectIds == null)
            {
                return RedirectToAction("ManageProjectUsers");
            }
            if (assignRemove)
            {
                //Iterate over each User and add them to each of the projects

                foreach (var userId in userIds)
                {
                    //Assign this person to each project
                    foreach (var projectId in projectIds)
                    {
                        projectHelper.AddUserToProject(userId, projectId);
                    }
                }
                TempData["Message"] = "Role has been successfully updated!";
                return RedirectToAction("ManageProjectUsers");
            }
            else
            {
                foreach (var userId in userIds)
                {
                    //Remove this person from each project
                    foreach (var projectId in projectIds)
                    {
                        projectHelper.RemoveUserFromProject(userId, projectId);
                    }
                }
                TempData["Message"] = "Role has been successfully updated!";
                return RedirectToAction("ManageProjectUsers");
            }
        }
        #endregion
    }
}