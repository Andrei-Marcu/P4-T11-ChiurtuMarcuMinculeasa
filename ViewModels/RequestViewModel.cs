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
        public User User { get; set; }
        public Book Book { get; set; }
        public int SubsidiaryID { get; set; }

        [Required]
        [Display(Name = "Date of Borrowing")]
        public DateTime? BorrowDate { get; set; }

        [Display(Name = "Return Deadline")]
        public DateTime? ReturnDeadline { get; set; }

        [Display(Name = "Return Date")]
        public DateTime? ReturnDate { get; set; }
        public int Status { get; set; }

        [Display(Name = "Message(optional)")]
        public string Message { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
