using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Cart
    {
        public int BookID { get; set; }

        public int UserID { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity can't be negative")]
        public int Quantity { get; set; }

        public Book Book { get; set; }

        public User User { get; set; }
    }
}
