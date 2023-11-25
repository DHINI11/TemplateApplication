using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TemplateApplication.Service.Interface;
using TemplateApplication.Models;
using Newtonsoft.Json;

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
            string apiUrl = APIBaseURL + "products/GetNew";
            List<UserDetail>? result = new List<UserDetail>();

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

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
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
