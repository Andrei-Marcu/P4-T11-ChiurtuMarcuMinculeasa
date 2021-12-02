using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Interface
{
    public interface IPaymentService<T>
    {
        void onSuccess(T details);

        void onFailure(T details);

        void onCancel(T details);
    }
}
