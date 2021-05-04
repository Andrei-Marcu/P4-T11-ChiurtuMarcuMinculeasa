using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public int SubsidiaryID { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDeadline { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Status { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
        public Subsidiary Subsidiary { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
