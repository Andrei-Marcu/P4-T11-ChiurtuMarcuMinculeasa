using LibraryManagement.Models;
using LibraryManagement.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Services
{
    public class StripePurchaseService : IPurchaseService<Purchase>
    {
        public int CreatePurchase(Purchase details)
        {
            throw new NotImplementedException();
        }

        public IActionResult getRedirect(int purchaseID)
        {
            throw new NotImplementedException();
        }
    }
}
