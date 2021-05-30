using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class RequestViewModel
    {
        public int UserID { get; set; }
        public int BookID { get; set; }
        public int SubsidiaryID { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDeadline { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
