using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class StockViewModel
    {
        [Required]
        public int SubsidiaryID { get; set; }
        [Required]
        public int Total { get; set; }
        public int Borrowed { get; set; }

        public bool Error { get; set; }
    }
}
