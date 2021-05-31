using LibraryManagement.Models;
using LibraryManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Utils.Services
{
    public class SubsidiaryService : ISubsidiaryService
    {
        private readonly ISubsidiaryRepository _subsidiaryRepository;

        public SubsidiaryService(ISubsidiaryRepository subsidiaryRepository)
        {
            _subsidiaryRepository = subsidiaryRepository;
        }

        public string getNamingById(int id)
        {
            var sub = _subsidiaryRepository.FindByCondition(m => m.SubsidiaryID == id)
                .Include(m => m.City).FirstOrDefault();
            return getNamingBySubsidiary(sub);
        }

        public string getNamingBySubsidiary(Subsidiary subsidiary)
        {
            return subsidiary.City.Name + " : " + subsidiary.Name;
        }

        public IEnumerable<KeyValuePair<int, string>> getSubsidiariesList(IEnumerable<int> exclude)
        {
            return _subsidiaryRepository.FindAll().Include(m => m.City)
                .Where(m => !exclude.Any(x => x == m.SubsidiaryID))
                .ToArray().Select(s => 
                    KeyValuePair.Create(s.SubsidiaryID, getNamingBySubsidiary(s))
                );
            
        }

        public IEnumerable<KeyValuePair<int, string>> getSubsidiariesList()
        {
            return _subsidiaryRepository.FindAll().Include(m => m.City)
                .ToArray().Select(s =>
                    KeyValuePair.Create(s.SubsidiaryID, getNamingBySubsidiary(s))
                );
        }
    }
}
