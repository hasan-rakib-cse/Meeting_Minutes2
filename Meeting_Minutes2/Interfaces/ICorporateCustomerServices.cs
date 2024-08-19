using Meeting_Minutes2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Minutes2.Interfaces
{
    public interface ICorporateCustomerServices
    {
        public IEnumerable<CorporateCustomer> GetCorporateCustomerList();

        public CorporateCustomer GetCorporateCustomerById(int? id);

        public void CreateCorporateCustomer(CorporateCustomer corpoCustomer);

        public void UpdateCorporateCustomer(CorporateCustomer corpoCustomer);

        public void DeleteCorporateCustomer(int? id);
    }
}
