using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Utils.Services
{
    public interface ISubsidiaryService
    {
        string getNamingById(int id);

        string getNamingBySubsidiary(Subsidiary subsidiary);

        IEnumerable<KeyValuePair<int, string>> getSubsidiariesList();
    }
}
