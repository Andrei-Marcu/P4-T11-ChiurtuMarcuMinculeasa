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

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            return View(await bookRepository.FindAll().ToListAsync());
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookRepository.FindByCondition(m => m.BookID == id).FirstOrDefaultAsync();
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
        public IActionResult Create([Bind("BookID,Publisher,Title")] Book book)
        {
            if (ModelState.IsValid)
            {
                bookRepository.Create(book);
                bookRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookRepository.FindByCondition(m => m.BookID == id).FirstOrDefaultAsync();
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
                    bookRepository.Update(book);
                    bookRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await bookRepository.FindByCondition(m => m.BookID == id).AnyAsync())
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

            var book = bookRepository.FindByCondition(m => m.BookID == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await bookRepository.FindByCondition(m => m.BookID == id).FirstOrDefaultAsync();
            bookRepository.Delete(book);
            bookRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
