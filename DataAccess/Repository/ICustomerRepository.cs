using BusinessObject.Object;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        IEnumerable<TypeCustomer> GetAllTypes();
        Customer GetById(string id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(string id);
    }
}
