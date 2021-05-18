using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Repositories
{
    public class StockRepository : RepositoryBase<Stock>, IStockRepository
    {
        public StockRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
