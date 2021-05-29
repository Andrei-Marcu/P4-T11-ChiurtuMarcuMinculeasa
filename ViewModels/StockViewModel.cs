using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class StockViewModel
    {
        public int SubsidiaryID { get; set; }
        public int Total { get; set; }
        public bool HasBorrowed { get; set; }
    }
}
