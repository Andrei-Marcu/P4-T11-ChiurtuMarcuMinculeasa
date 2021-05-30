using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using LibraryManagement.Utils.Services;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISubsidiaryService _subsidiaryService;
        private readonly UserManager<User> _userManager;

        public RequestController(ApplicationDbContext context, ISubsidiaryService subsidiaryService, UserManager<User> userManager)
        {
            _context = context;
            _subsidiaryService = subsidiaryService;
            _userManager = userManager;
        }

        // GET: Request
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requests.Include(r => r.Book).Include(r => r.Subsidiary).Include(r => r.User).OrderByDescending(r => r.RequestDate);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Request/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Book)
                .Include(r => r.Subsidiary)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Request/Create
        public IActionResult Create(int id)
        {
            ViewData["SubsidiaryID"] = new SelectList(_subsidiaryService.getSubsidiariesList(), "SubsidiaryID", "Address");
            return View();
        }

        // POST: Request/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(int id, RequestViewModel requestVM)
        {
            //TODO:check if book exists first

            if (ModelState.IsValid)
            {
                var request = new Request()
                {
                    UserID = int.Parse(_userManager.GetUserId(User)),
                    BookID = id,
                    SubsidiaryID = requestVM.SubsidiaryID,
                    RequestDate = requestVM.RequestDate,
                    Status = 0
                };

                _context.Add(request);
                //TODO: messages

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubsidiaryID"] = new SelectList(_subsidiaryService.getSubsidiariesList(), "SubsidiaryID", "Address", requestVM.SubsidiaryID);
            return View(requestVM);
        }

        // GET: Request/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            var requestVM = new RequestViewModel()
            {
                UserID = request.UserID,
                BookID = request.BookID,
                SubsidiaryID = request.SubsidiaryID,
                RequestDate = request.RequestDate,
                BorrowDate = request.BorrowDate,
                ReturnDeadline = request.ReturnDeadline,
                ReturnDate = request.ReturnDate,
                Status = request.Status,
                Message = string.Empty,
                Messages = request.Messages
            };


            ViewData["SubsidiaryID"] = new SelectList(_subsidiaryService.getSubsidiariesList(), "SubsidiaryID", "Address", requestVM.SubsidiaryID);
            return View(requestVM);
        }

        // POST: Request/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RequestViewModel requestVM)
        {
            if (!RequestExists(id))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var request = _context.Requests.Find(id);

                //TODO

                _context.Requests.Update(request);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubsidiaryID"] = new SelectList(_subsidiaryService.getSubsidiariesList(), "SubsidiaryID", "Address", requestVM.SubsidiaryID);
            return View(requestVM);
        }

        // GET: Request/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Book)
                .Include(r => r.Subsidiary)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestID == id);
        }
    }
}
