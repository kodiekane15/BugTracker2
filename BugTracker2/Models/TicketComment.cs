﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker2.Models
{
    public class TicketComment
    {
        public int Id { get; set; }
        #region Parent/Child
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        #endregion
        #region Properties
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        #endregion
    }
}