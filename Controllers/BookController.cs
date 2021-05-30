using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using LibraryManagement.ViewModels;
using LibraryManagement.Utils.Services;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BookController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;

        public BookController(IBookRepository bookRepository, IAuthorService authorService)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
        }

        // GET: Book
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _bookRepository.FindAll().ToListAsync());
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepository.FindByCondition(m => m.BookID == id).FirstOrDefaultAsync();
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book()
                {
                    Title = bookVM.Title,
                    Publisher = bookVM.Publisher,
                    Authors = _authorService.parseAuthors(bookVM.Authors)
                };
                _bookRepository.Create(book);
                _bookRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(bookVM);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepository.FindByCondition(m => m.BookID == id)
                .Include(m => m.Authors).Include(m => m.Stocks).FirstOrDefaultAsync();
            if (book == null)
            {
                return NotFound();
            }
            BookViewModel bookVM = new BookViewModel()
            {
                Title = book.Title,
                Publisher = book.Publisher,
                Authors = _authorService.stringifyAuthors(book.Authors),
                Stocks = book.Stocks.Select(stock => new StockViewModel()
                {
                    Borrowed = stock.Borrowed,
                    Total = stock.Total,
                    SubsidiaryID = stock.SubsidiaryID
                })
            };
            return View(bookVM);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                Book book = _bookRepository.FindByCondition(m => m.BookID == id)
                    .Include(m => m.Stocks).FirstOrDefault();

                if(book == null)
                {
                    return NotFound();
                }

                book.Title = bookVM.Title;
                book.Publisher = bookVM.Publisher;
                book.Authors = _authorService.parseAuthors(bookVM.Authors);

                List<Stock> toAdd = new List<Stock>();
                bool error = false;

                foreach(var stockVM in bookVM.Stocks)
                {
                    stockVM.Error = false;

                    var stock = book.Stocks
                        .Where(s => s.SubsidiaryID == stockVM.SubsidiaryID).FirstOrDefault();
                    if(stock == null)
                    {
                        toAdd.Add(new Stock()
                        {
                            //BookID = id,
                            SubsidiaryID = stockVM.SubsidiaryID,
                            Total = stockVM.Total
                        });
                    }
                    else
                    {
                        if(stockVM.Total < stock.Borrowed)
                        {
                            error = true;
                            stockVM.Error = true;
                            stockVM.Total = stock.Borrowed;
                        }
                    }
                }
                if (error) {
                    return View();
                }
                foreach(var stock in toAdd)
                {
                    book.Stocks.Add(stock);
                }

                _bookRepository.Update(book);
                _bookRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(bookVM);
        }

        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookRepository.FindByCondition(m => m.BookID == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.Delete(book);
            _bookRepository.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
