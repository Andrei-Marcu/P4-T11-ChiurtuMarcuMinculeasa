using LibraryManagement.Models;
using LibraryManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Utils.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        private readonly City defaultCity = new City() { Name = "Select your city:", CityID = 0 };
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<City> GetCities()
        {
            return _cityRepository.FindAll().AsEnumerable();
        }

        public IEnumerable<City> GetCitiesWithDefault()
        {
            return GetCities().Prepend(defaultCity);
        }
    }
}
