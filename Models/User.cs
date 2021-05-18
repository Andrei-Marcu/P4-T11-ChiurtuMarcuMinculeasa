using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class User : IdentityUser<int>
    {
        public int CityID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public bool Blacklisted { get; set; }

        public City City { get; set; }
        public ICollection<Request> Requests { get; set; }

}
}
