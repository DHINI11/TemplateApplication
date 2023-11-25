using TemplateApplication.Models;

namespace TemplateApplication.Service.Interface
{
    public interface IProductService
    {
        Task<List<UserDetail>> GetProducts();
        Task<UserDetail> GetProductById(int id);
        Task AddProduct(UserDetail product);
        Task UpdateProduct(UserDetail product);
        Task DeleteProduct(int id);
    }

}
