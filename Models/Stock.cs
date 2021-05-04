using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Stock
    {
        public int StockID { get; set; }
        public int BookID { get; set; }
        public int SubsidiaryID { get; set; }
        public int Total { get; set; }
        public int Borrowed { get; set; }

        public Book Book { get; set; }
        public Subsidiary Subsidiary { get; set; }
    }
}
