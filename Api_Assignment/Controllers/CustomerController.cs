using BusinessObject.Object;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api_Assignment.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repo;
        public CustomerController(ICustomerRepository repo) => _repo = repo;

        /**
         * [GET]
         * api/customer/getAll
        */
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list = _repo.GetAll();
            if (list == null)
            {
                return NotFound("Empty list.");
            }
            return Ok(list);
        }

        /**
         * [GET]
         * api/customer/getAllOfTypes
        */
        [HttpGet("getAllOfTypes")]
        public IActionResult GetTypes()
        {
            var list = _repo.GetAllTypes();
            if (list == null)
            {
                return NotFound("Empty list.");
            }
            return Ok(list);
        }

        /**
         * [GET]
         * api/customer/2
        */
        [HttpGet("{id}", Name = "getById")]
        public IActionResult GetById(string id)
        {
            var customer = _repo.GetById(id);

            if (customer == null)
            {
                return NotFound("Not found.");
            }
            return Ok(customer);
        }

        /**
         * [POST]
         * api/customer/add
        */
        [HttpPost("add", Name = "add")]
        public IActionResult AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Information is required.");
            }

            if (ModelState.IsValid)
            {
                _repo.Add(customer);
            }
            return CreatedAtRoute("getById", new { id = customer.Id }, new
            {
                customer.Id,
                customer.Fullname,
                customer.Birthday,
                customer.Male,
                customer.PhoneNumber,
                customer.Email,
                customer.Points,
                customer.TypeCustomer
            });
        }

        /**
         * [DELETE]
         * api/customer/delete/3
        */
        [HttpDelete("delete/{id}", Name = "delete")]
        public IActionResult DeleteCustomer(string id)
        {
            var prod = _repo.GetById(id);
            if (prod == null)
            {
                return BadRequest("This id not exists.");
            }
            _repo.Delete(id);
            return Ok(prod);
        }

        /**
         * [PUT]
         * api/customer/edit/3
        */
        [HttpPut("edit/{id}", Name = "edit")]
        public IActionResult UpdateCustomer(string id, Customer cus)
        {
            if (cus == null)
            {
                return BadRequest("Information is required.");
            }
            Customer obj = _repo.GetById(id);
            if (obj == null)
            {
                return NotFound("The customer is not exists.");
            }
            _repo.Update(cus);
            return Ok(cus);
        }
    }
}
