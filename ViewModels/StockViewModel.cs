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
        [Range(0, int.MaxValue, ErrorMessage = "Total must be a positive number")]
        public int Total { get; set; }

        public bool Error { get; set; }
    }
}
