using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Subsidiary
    {
        public int SubsidiaryID { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public City City { get; set; }
    }
}
