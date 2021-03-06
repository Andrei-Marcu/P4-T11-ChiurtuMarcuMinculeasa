using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Utils.Services
{
    public interface ICityService
    {
        IEnumerable<City> GetCities();

        IEnumerable<City> GetCitiesWithDefault();
    }
}
