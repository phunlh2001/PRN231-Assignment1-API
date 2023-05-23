using BusinessObject.Object;
using Client_MVC.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Client_MVC.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly HttpClient client;
        private string api;

        public CustomerController()
        {
            client = new HttpClient();
            var contenType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contenType);
            api = "https://localhost:3001/api/customer";
        }

        #region Index
        /**
         * [GET]
         * Index View
        */
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await client.GetApi<IEnumerable<Customer>>($"{api}/getAll");
            ViewData["types"] = await client.GetApi<IEnumerable<TypeCustomer>>($"{api}/getAllOfTypes");
            return View(list);
        }
        #endregion

        #region Create
        /**
         * [GET]
         * Create View
        */
        [HttpGet("add", Name = "add")]
        public async Task<IActionResult> Create()
        {
            var types = await client.GetApi<IEnumerable<TypeCustomer>>($"{api}/getAllOfTypes");
            ViewData["type"] = new SelectList(types, "Id", "Name");

            return View();
        }

        /**
         * [POST]
         * Craete View
        */
        [HttpPost("add")]
        public async Task<IActionResult> Create(bool gender, Customer obj)
        {
            if (ModelState.IsValid)
            {
                if (gender)
                {
                    obj.Male = true;
                }
                else
                {
                    obj.Male = false;
                }

                obj.Birthday = DateTime.Parse(obj.Birthday).ToString("dd/MM/yyyy");


                HttpResponseMessage res = await client.PostApi(obj, $"{api}/add");
                if (res.StatusCode == HttpStatusCode.Created)
                {
                    return Redirect("/customer");
                }
            }
            else
            {
                var types = await client.GetApi<IEnumerable<TypeCustomer>>($"{api}/getAllOfTypes");
                ViewData["type"] = new SelectList(types, "id", "name");
            }
            return View(obj);
        }
        #endregion

        #region Edit
        /**
         * [GET]
         * Update View
        */
        [HttpGet("edit/{id}", Name = "edit")]
        public async Task<IActionResult> Update(string id)
        {
            var cus = await client.GetApi<Customer>($"{api}/{id}");
            var types = await client.GetApi<IEnumerable<TypeCustomer>>($"{api}/getAllOfTypes");
            ViewData["type"] = new SelectList(types, "Id", "Name");

            return View(cus);
        }

        /**
         * [POST]
         * Update View
        */
        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Update(int id, bool gender, Customer obj)
        {
            if (ModelState.IsValid)
            {
                if (gender)
                {
                    obj.Male = true;
                }
                else
                {
                    obj.Male = false;
                }

                obj.Birthday = DateTime.Parse(obj.Birthday).ToString("dd/MM/yyyy");

                HttpResponseMessage res = await client.PutApi(obj, $"{api}/edit/{id}");

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    return Redirect("/customer");
                }
            }
            else
            {
                var types = await client.GetApi<IEnumerable<TypeCustomer>>($"{api}/getAllOfTypes");
                ViewData["type"] = new SelectList(types, "Id", "Name");
            }
            return View();
        }
        #endregion

        #region Delete
        /**
         * [GET]
         * Delete View
        */
        [HttpGet("delete/{id}", Name = "delete")]
        public async Task<IActionResult> Delete(Customer obj)
        {
            var cus = await client.GetApi<Customer>($"{api}/{obj.Id}");
            ViewData["typeOfCus"] = await client.GetApi<IEnumerable<TypeCustomer>>($"{api}/getAllOfTypes");

            return View(cus);
        }

        /**
         * [POST]
         * Delete View
        */
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            HttpResponseMessage res = await client.DeleteAsync($"{api}/delete/{id}");
            if (res.StatusCode == HttpStatusCode.OK)
            {
                return Redirect("/customer");
            }
            return View();
        }
        #endregion
    }
}
