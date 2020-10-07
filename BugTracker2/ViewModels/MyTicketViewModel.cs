using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTracker2.Models;
namespace BugTracker2.ViewModels
{
    public class MyTicketViewModel
    {
       public List<Ticket> AllTickets { get; set; }
       public List<Ticket> MyTickets { get; set; }
    }
}