using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public int? UserID { get; set; }
        public int RequestID { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        [Required]
        public string Content { get; set; }

        public User User { get; set; }
    }
}
