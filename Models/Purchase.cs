using LibraryManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }

        public decimal Price { get; set; }

        public StatusEnum Status { get; set; }

        public List<Book> Books { get; set; }
    }
}
