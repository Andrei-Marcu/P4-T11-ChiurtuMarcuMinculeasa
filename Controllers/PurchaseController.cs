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
using LibraryManagement.Service.Interface;
using LibraryManagement.Repository.Interfaces;
using LibraryManagement.Enums;

namespace LibraryManagement.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        private readonly IPaymentService<int> _paymentService;
        private readonly IPurchaseService<int> _purchaseService;
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseController(IPaymentService<int> paymentService, IPurchaseService<int> purchaseService, IPurchaseRepository purchaseRepository)
        {
            _paymentService = paymentService;
            _purchaseService = purchaseService;
            _purchaseRepository = purchaseRepository;
        }

        // GET: Purchase
        /*public async Task<IActionResult> Index()
        {
            return View(await _context.Purchases.ToListAsync());
        }*/

        // GET: Purchase/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases
                .FirstOrDefaultAsync(m => m.PurchaseID == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }*/

        // GET: Purchase/Create
        [HttpGet]
        public IActionResult Create(int bookID)
        {
            return RedirectToAction(nameof(Edit),new { 
                id = _purchaseService.CreatePurchase(bookID)
            });
            //return Edit(_purchaseService.CreatePurchase(bookID));
            //return View();
        }

        // GET: Purchase/Edit/5
        public IActionResult Edit(int id)
        {
            var purchase = _purchaseRepository.FindByCondition(p => p.PurchaseID == id).FirstOrDefault();
            if (purchase == null)
            {
                return NotFound();
            }
            ViewBag.Status = new SelectList(
                Enum.GetValues<StatusEnum>().Skip(1).Select(s => new KeyValuePair<StatusEnum, string>(s, s.ToString())),
                "Key", "Value", StatusEnum.Successful.ToString());
            return View(purchase);
        }

        // POST: Purchase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Purchase purchase)
        {

            if (ModelState.IsValid)
            {
                switch (purchase.Status)
                {
                    case Enums.StatusEnum.Successful:
                        return OnSuccess(purchase.PurchaseID);
                    case Enums.StatusEnum.Failed:
                        return OnFailure(purchase.PurchaseID);
                    case Enums.StatusEnum.Cancelled:
                        return OnCancel(purchase.PurchaseID);
                    case Enums.StatusEnum.New:
                        return Edit(purchase.PurchaseID);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(purchase);
        }

        public IActionResult OnSuccess(int id)
        {
            _paymentService.onSuccess(id);
            return Redirect("/");
        }
        public IActionResult OnFailure(int id)
        {
            _paymentService.onFailure(id);
            return Redirect("/");
        }
        public IActionResult OnCancel(int id)
        {
            _paymentService.onCancel(id);
            return Redirect("/");
        }

        /*
        // GET: Purchase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases
                .FirstOrDefaultAsync(m => m.PurchaseID == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchases.Any(e => e.PurchaseID == id);
        }
        */
    }
}
