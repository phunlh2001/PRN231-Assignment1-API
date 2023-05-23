using BusinessObject.Object;
using DataAccess.Dao;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Add(Customer customer) => CustomerDao.GetInstance.Add(customer);

        public void Delete(string id) => CustomerDao.GetInstance.Delete(id);

        public IEnumerable<Customer> GetAll() => CustomerDao.GetInstance.GetAll();

        public IEnumerable<TypeCustomer> GetAllTypes() => CustomerDao.GetInstance.GetAllTypes();

        public Customer GetById(string id) => CustomerDao.GetInstance.GetById(id);

        public void Update(Customer customer) => CustomerDao.GetInstance.Update(customer);
    }
}
