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

        public override IQueryable<Author> FindAll()
        {
            return DbContext.Set<Author>();
        }

        public override IQueryable<Author> FindByCondition(Expression<Func<Author, bool>> expression)
        {
            return DbContext.Set<Author>().Where(expression);
        }
    }
}
