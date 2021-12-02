using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Interface
{
    public interface IPurchaseService<T>
    {
        IActionResult getRedirect(int purchaseID);

        int CreatePurchase(T details);
    }
}
