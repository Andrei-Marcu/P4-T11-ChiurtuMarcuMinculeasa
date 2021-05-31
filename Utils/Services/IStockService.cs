using LibraryManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Utils.Services
{
    public interface IStockService
    {
        bool UpdateStocks(StockViewModel[] stocks, int bookId);
    }
}
