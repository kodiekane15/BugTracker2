﻿using BugTracker2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker2.Helpers
{
    public class TicketHelper
    {
        private UserRoleHelper roleHelper = new UserRoleHelper();
        private ApplicationDbContext db = new ApplicationDbContext();
        public bool CanEditTicket(int ticketId)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var myRole = roleHelper.ListUserRoles(userId).FirstOrDefault();
            switch (myRole)
            {
                case "Admin":
                    return true;

                case "Project Manager":
                    var user = db.Users.Find(userId);
                    return (user.Projects.SelectMany(p => p.Tickets).Any(t => t.Id == ticketId));
                case "Developer":
                case "Submitter":
                    var ticket = db.Tickets.Find(ticketId);
                    if (ticket.DeveloperId == userId || ticket.SubmitterId == userId)
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                default:
                    return false;
            }

        }

        public bool CanMakeComment(int ticketId)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var myRole = roleHelper.ListUserRoles(userId).FirstOrDefault();
            switch (myRole)
            {
                case "Admin":
                    return true;

                case "Project Manager":
                    var user = db.Users.Find(userId);
                    return (user.Projects.SelectMany(p => p.Tickets).Any(t => t.Id == ticketId));
                case "Developer":
                case "Submitter":
                    var ticket = db.Tickets.Find(ticketId);
                    if (ticket.DeveloperId == userId || ticket.SubmitterId == userId)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }

        }

    }
}