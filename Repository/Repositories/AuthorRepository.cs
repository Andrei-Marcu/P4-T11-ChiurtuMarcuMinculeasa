using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
