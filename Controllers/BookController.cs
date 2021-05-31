using LibraryManagement.Models;
using LibraryManagement.Repository.Interfaces;
using LibraryManagement.Utils.Services;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BookController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;
        private readonly ISubsidiaryService _subsidiaryService;

        public BookController(IBookRepository bookRepository, IAuthorService authorService, ISubsidiaryService subsidiaryService)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
            _subsidiaryService = subsidiaryService;
        }

        // GET: Book
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _bookRepository.FindAll().Include(b => b.Authors).ToListAsync());
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
                return RedirectToAction(nameof(Edit), new { id = book.BookID });
            }
            return View(bookVM);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

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
                    //Borrowed = stock.Borrowed,
                    Total = stock.Total,
                    SubsidiaryID = stock.SubsidiaryID
                }).ToArray()
            };
            ViewBag.Subsidiaries = new SelectList(_subsidiaryService
                .getSubsidiariesList(bookVM.Stocks.Select(s => s.SubsidiaryID))
                , "Key", "Value");
                
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
                //empty array is null in POST, We don't want that
                bookVM.Stocks ??= new StockViewModel[0];

                Book book = _bookRepository.FindByCondition(m => m.BookID == id)
                    .Include(m => m.Stocks).FirstOrDefault();

                if(book == null)
                {
                    return NotFound();
                }

                //do we add new stock?
                if (bookVM.StockID != 0)
                {
                    var list = bookVM.Stocks.ToList();
                    list.Add(new StockViewModel
                    {
                        SubsidiaryID = bookVM.StockID,
                        Total = 0,
                        //Borrowed = 0
                    });
                    bookVM.Stocks = list.ToArray();
                    bookVM.StockID = 0;
                    goto redisplay;
                }

                //reset errors to check again later
                foreach (var stock in bookVM.Stocks)
                {
                    stock.Error = false;
                }

                _bookRepository.LoadCollection(book, b => b.Stocks);

                /*Check for stock that is in an illegal state(i.e. the total went below the borrowed amount)
                 This is not POST attack proof but since this is accessed only by administrators and this is not
                 going to be deployed anywhere, no measures against it will be taken*/
                var illegalStocks = bookVM.Stocks.Where(mstock =>
                {
                    var bstock = book.Stocks.FirstOrDefault(bs => bs.SubsidiaryID == mstock.SubsidiaryID);
                    if (bstock == null)
                        return false;
                    else
                    {
                        return mstock.Total < bstock.Borrowed;
                    }
                });

                //set errors in this case
                if (illegalStocks.Count() > 0)
                {
                    foreach(var illStock in illegalStocks)
                    {
                        illStock.Error = true;
                    }
                    goto redisplay;
                }

                //replace stocks
                book.Stocks = bookVM.Stocks.Where(vm => vm.Total != 0)
                    .Select(stockVM => new Stock()
                    {
                        SubsidiaryID = stockVM.SubsidiaryID,
                        Total = stockVM.Total,
                        Borrowed = book.Stocks.Any(s => s.SubsidiaryID == stockVM.SubsidiaryID) ?
                                    book.Stocks.Where(s => s.SubsidiaryID == stockVM.SubsidiaryID).First().Borrowed
                                    : 0
                    }).ToList();

                //setting other values
                book.Title = bookVM.Title;
                book.Publisher = bookVM.Publisher;
                _bookRepository.LoadCollection(book, b => b.Authors);
                book.Authors = _authorService.parseAuthors(bookVM.Authors);

                //success
                _bookRepository.Update(book);
                _bookRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            redisplay:
            ViewBag.Subsidiaries = new SelectList(_subsidiaryService
                .getSubsidiariesList(bookVM.Stocks.Select(s => s.SubsidiaryID))
                , "Key", "Value");
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
