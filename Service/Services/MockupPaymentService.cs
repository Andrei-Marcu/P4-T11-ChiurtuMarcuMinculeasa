using LibraryManagement.Enums;
using LibraryManagement.Repository.Interfaces;
using LibraryManagement.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Services
{
    public class MockupPaymentService : IPaymentService<int>
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public MockupPaymentService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public void onCancel(int details)
        {
            update(details, StatusEnum.Cancelled);
        }

        public void onFailure(int details)
        {
            update(details, StatusEnum.Failed);
        }

        public void onSuccess(int details)
        {
            update(details, StatusEnum.Successful);
        }

        void update(int id, StatusEnum status)
        {
            var purchase = _purchaseRepository.FindByCondition(p => p.PurchaseID == id).FirstOrDefault();
            purchase.Status = status;
            _purchaseRepository.Update(purchase);
            _purchaseRepository.Save();
        }
    }
}
