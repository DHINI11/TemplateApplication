using TemplateApplication.Models;

namespace TemplateApplication.Repository.Interface
{
    public interface IProductRepository
    {
        Task<List<UserDetail>> GetProducts();
        Task<UserDetail> GetProductById(int id);
        Task AddProduct(UserDetail product);
        Task UpdateProduct(UserDetail product);
        Task DeleteProduct(int id);
    }
}
