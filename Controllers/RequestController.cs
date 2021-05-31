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
using LibraryManagement.Repository.Interfaces;

namespace LibraryManagement.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IRequestRepository _requestRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ISubsidiaryService _subsidiaryService;
        private readonly IStatusService _statusService;
        private readonly UserManager<User> _userManager;

        public RequestController(IRequestRepository requestRepository,
            IMessageRepository messageRepository,
            IBookRepository bookRepository,
            ISubsidiaryService subsidiaryService,
            IStatusService statusService,
            UserManager<User> userManager)
        {
            _requestRepository = requestRepository;
            _messageRepository = messageRepository;
            _bookRepository = bookRepository;
            _subsidiaryService = subsidiaryService;
            _statusService = statusService;
            _userManager = userManager;
        }



        // GET: Request
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _requestRepository.FindAll().Include(r => r.Book).Include(r => r.Subsidiary).Include(r => r.User).OrderByDescending(r => r.RequestDate);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Request/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _requestRepository.FindByCondition(m => m.RequestID == id)
                .Include(r => r.Book)
                .Include(r => r.Subsidiary)
                .Include(r => r.User)
                .FirstOrDefaultAsync();
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Request/Create
        public IActionResult Create(int id)
        {
            ViewBag.SubsidiaryID = new SelectList(_subsidiaryService.getSubsidiariesList(), "Key", "Value");
            return View();
        }

        // POST: Request/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(int id, RequestViewModel requestVM)
        {
            if(!_bookRepository.FindByCondition(b => b.BookID == id).Any())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var request = new Request()
                {
                    UserID = int.Parse(_userManager.GetUserId(User)),
                    BookID = id,
                    SubsidiaryID = requestVM.SubsidiaryID,
                    RequestDate = DateTime.Now,
                    Status = 0
                };

                _requestRepository.Create(request);
                _requestRepository.Save();

                leaveMessage(request, requestVM.Message);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubsidiaryID"] = new SelectList(_subsidiaryService.getSubsidiariesList(), "Key", "Value", requestVM.SubsidiaryID);
            return View(requestVM);
        }

        // GET: Request/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var request = await _requestRepository.FindByCondition(m => m.RequestID == id)
                .Include(m => m.User).Include(m => m.Book).FirstOrDefaultAsync();
            if (request == null)
            {
                return NotFound();
            }

            if (!User.IsInRole("Administrator") && _userManager.GetUserId(User) != request.UserID.ToString())
            {
                return Forbid();
            }

            var requestVM = new RequestViewModel()
            {
                User = request.User,
                Book = request.Book,
                SubsidiaryID = request.SubsidiaryID,
                BorrowDate = request.BorrowDate,
                ReturnDeadline = request.ReturnDeadline,
                ReturnDate = request.ReturnDate,
                Status = request.Status,
                Message = string.Empty,
                Messages = request.Messages
            };


            ViewData["SubsidiaryID"] = new SelectList(_subsidiaryService.getSubsidiariesList(), "Key", "Value", requestVM.SubsidiaryID);
            return View(requestVM);
        }

        // POST: Request/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RequestViewModel requestVM)
        {
            var request = await _requestRepository.FindByCondition(m => m.RequestID == id)
                .Include(m => m.User).Include(m => m.Book).FirstOrDefaultAsync();
            if (request == null)
            {
                return NotFound();
            }
            if (!User.IsInRole("Administrator") && _userManager.GetUserId(User) != request.UserID.ToString())
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                request.SubsidiaryID = requestVM.SubsidiaryID;
                request.BorrowDate = requestVM.BorrowDate;
                request.ReturnDeadline = requestVM.ReturnDeadline;
                request.ReturnDate = requestVM.ReturnDate;

                _requestRepository.Update(request);
                _requestRepository.Save();

                leaveMessage(request, requestVM.Message);
                return RedirectToAction(nameof(Index));
            }

            requestVM.User = request.User;
            requestVM.Book = request.Book;
            requestVM.Messages = request.Messages;
            ViewData["SubsidiaryID"] = new SelectList(_subsidiaryService.getSubsidiariesList(), "Key", "Value", requestVM.SubsidiaryID);
            return View(requestVM);
        }

        // GET: Request/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _requestRepository.FindByCondition(m => m.RequestID == id)
                .Include(r => r.Book)
                .Include(r => r.Subsidiary)
                .Include(r => r.User)
                .FirstOrDefaultAsync();
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
            var request = await _requestRepository.FindByCondition(m => m.RequestID == id).FirstOrDefaultAsync();
            _requestRepository.Delete(request);
            _requestRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        void leaveMessage(Request request, string message)
        {
            if (!String.IsNullOrEmpty(message))
            {
                _messageRepository.Create(new Message()
                {
                    UserID = int.Parse(_userManager.GetUserId(User)),
                    RequestID = request.RequestID,
                    Date = DateTime.Now,
                    Status = request.Status,
                    Content = message
                });
                _messageRepository.Save();
            }
        }
    }
}
