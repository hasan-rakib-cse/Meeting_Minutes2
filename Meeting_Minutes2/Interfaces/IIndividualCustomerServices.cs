using Meeting_Minutes2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Minutes2.Interfaces
{
    public interface IIndividualCustomerServices
    {
        public IEnumerable<IndividualCustomer> GetIndividualCustomerList();

        public IndividualCustomer GetIndividualCustomerById(int? id);

        public void CreateIndividualCustomer(IndividualCustomer indiCustomer);

        public void UpdateIndividualCustomer(IndividualCustomer indiCustomer);

        public void DeleteIndividualCustomer(int? id);
    }
}
