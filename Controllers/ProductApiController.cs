using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TemplateApplication.Models;
using TemplateApplication.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// Dev Branch
namespace TemplateApplication.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductApiController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("GetTableData")]
        [HttpGet]
        public Task<List<UserDetail>> GetTableData()
        {
            return _productService.GetAllActiveUser();
        }

        [Route("UpdateUser")]
        [HttpPost]
        public Task<bool> UpdateUser(UserDetail ?UserInfo)
        {

            try
            {
                if (UserInfo != null)
                {
                    return _productService.UpdateorDeleteUser(UserInfo);

                }
                else {

                    return  Task.FromResult(false);
                }


            }
            catch(Exception ex)
            {
                return Task.FromResult(false);
            }
            
        }

        [Route("AddUser")]
        [HttpPost]
        public async Task<List<UserDetail>> AddNewUser(UserDetail UserInfo)
        {

           return await _productService.AddUser(UserInfo);
        }



    }
}
