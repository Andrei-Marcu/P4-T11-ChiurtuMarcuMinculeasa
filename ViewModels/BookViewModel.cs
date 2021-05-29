using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Authors { get; set; }
        public ICollection<StockViewModel> Stocks { get; set; }
    }
}
