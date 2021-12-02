using LibraryManagement.Controllers;
using LibraryManagement.Models;
using LibraryManagement.Repository.Interfaces;
using LibraryManagement.Repository.Repositories;
using LibraryManagement.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Services
{
    public class MockupPurchaseService : IPurchaseService<int>
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IBookRepository _bookRepository;

        public MockupPurchaseService(IPurchaseRepository purchaseRepository, IBookRepository bookRepository)
        {
            _purchaseRepository = purchaseRepository;
            _bookRepository = bookRepository;
        }

        public int CreatePurchase(int details)
        {
            Book book = _bookRepository.FindByCondition(b => b.BookID == details).FirstOrDefault();
            var purchase = new Purchase()
            {
                Status = Enums.StatusEnum.New,
                Price = book.Price,
                Books = new List<Book>() { book }
            };
            _purchaseRepository.Create(purchase);
            _purchaseRepository.Save();
            return purchase.PurchaseID;
        }

        public IActionResult getRedirect(int purchaseID)
        {
            throw new NotImplementedException();
        }
    }
}
