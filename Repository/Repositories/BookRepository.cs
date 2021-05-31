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
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {

        public BookRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }

        public override IQueryable<Book> FindByCondition(Expression<Func<Book, bool>> expression)
        {
            return DbContext.Set<Book>().Where(expression);
        }
    }
}
