using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Utils.Services
{
    public interface IAuthorService
    {
        ICollection<Author> parseAuthors(string authorsString);
        string stringifyAuthors(ICollection<Author> authors);
    }
}
