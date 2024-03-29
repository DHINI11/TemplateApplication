﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TemplateApplication.Service.Interface;
using TemplateApplication.Models;
using Newtonsoft.Json;
using System.Text;

namespace TemplateApplication.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        private readonly ILogger<ProductController> _logger;
        private readonly IConfiguration _configuration;
        public readonly string APIBaseURL;

        public ProductController(ILogger<ProductController> logger,IProductService productService, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _productService = productService;
            APIBaseURL = _configuration["MySettings:ApiBaseUrl"];

        }


        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            string apiUrl = APIBaseURL + "products/GetTableData";
            List<UserDetail>? result = new List<UserDetail>();
            ViewBag.APIBaseURL = APIBaseURL;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        if (data != null)
                        {
                            result = JsonConvert.DeserializeObject<List<UserDetail>>(data);
                        }
                    }
                    else
                    {
                        // Handle the error
                        ViewBag.Result = "Error: " + response.StatusCode + " " + response.ReasonPhrase;
                    }
                }
                return View(result);
            }
            catch (Exception ex)
            {
                ViewBag.Result = ex.Message;
                return View();
            }

            
           
        }

        public async Task<ActionResult> UpdateTableUser(UserDetail UserData)
        {
            string apiUrl = APIBaseURL + "products/UpdateUser";
            List<UserDetail>? result = new List<UserDetail>();

            if (UserData != null) 
            {
                var jsonContent = JsonConvert.SerializeObject(UserData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                
                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        var response = await httpClient.PostAsync(apiUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync();
                            if (responseData == "true")
                            {
                                apiUrl = APIBaseURL + "products/GetTableData";
                                response = await httpClient.GetAsync(apiUrl);
                                if (response.IsSuccessStatusCode) {


                                    string data = await response.Content.ReadAsStringAsync();
                                    if (data != null)
                                    {
                                        result = JsonConvert.DeserializeObject<List<UserDetail>>(data);
                                    }

                                }
                            }
                        }
                        else
                        {
                            // Handle the error response
                            Console.WriteLine($"Error: {response.ReasonPhrase}");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        Console.WriteLine($"Exception: {ex.Message}");
                    }

                }


            }
           

            return PartialView("_TablePartial", result);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
