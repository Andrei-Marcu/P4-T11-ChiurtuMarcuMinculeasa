using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Repository.Repositories;
using LibraryManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagement.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IBookRepository _bookRepository;
        private readonly UserManager<User> _userManager;

        public CartController(ICartRepository cartRepository, IBookRepository bookRepository, UserManager<User> userManager)
        {
            _cartRepository = cartRepository;
            _bookRepository = bookRepository;
            _userManager = userManager;
        }

        // GET: Cart
        public IActionResult Index()
        {
            return View(_cartRepository
                .FindByCondition(
                    c => c.UserID == int.Parse(_userManager.GetUserId(User)))
                .Include(c => c.Book));
        }

        public IActionResult Details()
        {
            return View(_cartRepository
                .FindByCondition(
                    c => c.UserID == int.Parse(_userManager.GetUserId(User)))
                .Include(c => c.Book).FirstOrDefault());
        }

        // GET: Cart/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Book)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "Publisher");
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Address");
            return View();
        }*/

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        public async Task<IActionResult> Create(int bookId)
        {

            if (_bookRepository.FindByCondition(b => b.BookID == bookId).Any())
            {
                var userId = int.Parse(_userManager.GetUserId(User));
                var cart = await _cartRepository.FindByCondition(c => c.UserID == userId && c.BookID == bookId).FirstOrDefaultAsync();
                if (cart != null)
                {
                    cart.Quantity++;
                    _cartRepository.Update(cart);
                    
                }
                else
                {
                    _cartRepository.Create(new Cart()
                    {
                        BookID = bookId,
                        UserID = userId,
                        Quantity = 1,
                    });
                }
                _cartRepository.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Cart/Edit/5
        /*public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "Publisher", cart.BookID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Address", cart.UserID);
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cart cart)
        {
            if (cart.Quantity != 0 && _bookRepository.FindByCondition(b => b.BookID == cart.BookID).Any())
            {
                var userId = int.Parse(_userManager.GetUserId(User));
                if (ModelState.IsValid && (cart.UserID == userId || cart.UserID == 0))
                {
                    cart.UserID = userId;
                    _cartRepository.Update(cart);
                    _cartRepository.Save();
                }
            }
            else
            {
                _cartRepository.Delete(cart);
                _cartRepository.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int bookId)
        {
            var userId = int.Parse(_userManager.GetUserId(User));
            var cart = await _cartRepository.FindByCondition(c => c.UserID == userId && c.BookID == bookId).FirstOrDefaultAsync();
            if (cart != null)
            {
                _cartRepository.Delete(cart);
                _cartRepository.Save();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
