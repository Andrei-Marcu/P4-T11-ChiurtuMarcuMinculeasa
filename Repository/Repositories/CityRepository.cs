using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
