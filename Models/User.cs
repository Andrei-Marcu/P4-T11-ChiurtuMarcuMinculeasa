using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class User
    {
        public int UserID { get; set; }
        public int CityID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
        public bool Blacklisted { get; set; }

        public City City { get; set; }
        public ICollection<Request> Requests { get; set; }

}
}
