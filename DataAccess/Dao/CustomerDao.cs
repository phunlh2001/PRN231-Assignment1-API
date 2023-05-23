using BusinessObject;
using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dao
{
    public class CustomerDao
    {
        //Singleton Design Pattern
        private static CustomerDao instance;
        private static readonly object instanceLock = new object();
        public static CustomerDao GetInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDao();
                    }
                    return instance;
                }
            }
        }

        /** 
         * [List<Customer>]
         * Get All Customers
        */
        public IEnumerable<Customer> GetAll()
        {
            var cus = new List<Customer>();
            try
            {
                using var context = new ApplicationDbContext();
                cus = context.Customers.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cus;
        }

        /** 
         * [List<TypeCustomers>]
         * Get All TypeCustomers
        */
        public IEnumerable<TypeCustomer> GetAllTypes()
        {
            var cus = new List<TypeCustomer>();
            try
            {
                using var context = new ApplicationDbContext();
                cus = context.TypeCustomers.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cus;
        }

        /** 
         * [TypeCustomer]
         * Get TypeCustomer By Id
        */
        public TypeCustomer GetTypeById(string id)
        {
            TypeCustomer cus = null;
            try
            {
                using var context = new ApplicationDbContext();
                cus = context.TypeCustomers.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cus;
        }

        /** 
         * [Customer]
         * Get Customer By Id
        */
        public Customer GetById(string id)
        {
            Customer cus = null;
            try
            {
                using var context = new ApplicationDbContext();
                cus = context.Customers.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cus;
        }

        /** 
         * [void]
         * Add A Customer
        */
        public void Add(Customer customer)
        {
            try
            {
                Customer cus = GetById(customer.Id);
                if (cus == null)
                {
                    using var context = new ApplicationDbContext();
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Customer is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /** 
         * [void]
         * Update A Customer By Id
        */
        public void Update(Customer customer)
        {
            try
            {
                Customer cus = GetById(customer.Id);
                if (cus != null)
                {
                    using var context = new ApplicationDbContext();
                    context.Customers.Update(customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Customer does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /** 
         * [void]
         * Delete A Customer By Id
        */
        public void Delete(string id)
        {
            try
            {
                Customer cus = GetById(id);
                if (cus != null)
                {
                    using var context = new ApplicationDbContext();
                    context.Customers.Remove(cus);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Customer is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
