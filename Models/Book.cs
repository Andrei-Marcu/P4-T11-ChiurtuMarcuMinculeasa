using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Book
    {
        public int BookID { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Title { get; set; }

        public ICollection<Author> Authors { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}
