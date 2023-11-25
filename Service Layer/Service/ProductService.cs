using TemplateApplication.Models;
using TemplateApplication.Repository.Interface;
using TemplateApplication.Service.Interface;

namespace TemplateApplication.Service.Repository
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task AddProduct(UserDetail product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetail> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDetail>> GetProducts()
        {
           return _repository.GetProducts();
        }

        public Task UpdateProduct(UserDetail product)
        {
            throw new NotImplementedException();
        }

        // Implement service methods
    }
}
