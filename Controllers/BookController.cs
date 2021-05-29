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

            var book = await _bookRepository.FindByCondition(m => m.BookID == id).FirstOrDefaultAsync();
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,Publisher,Title")] Book book)
        {
            if (id != book.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bookRepository.Update(book);
                    _bookRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _bookRepository.FindByCondition(m => m.BookID == id).AnyAsync())
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
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

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _bookRepository.FindByCondition(m => m.BookID == id).FirstOrDefaultAsync();
            _bookRepository.Delete(book);
            _bookRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
