using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace BugTracker2.Models
{
    public class TicketNotification
    {
        public int Id { get; set; }
        #region Parent/Child
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        #endregion
        #region Properties
        public string Subject { get; set; }
        public string Message { get; set; }

        public DateTime Created { get; set; }
        public bool IsRead { get; set; }

        #endregion
    }
}