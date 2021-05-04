using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }

        public ICollection<Author> Authors { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}
