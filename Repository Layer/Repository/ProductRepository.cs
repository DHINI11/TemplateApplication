using Microsoft.EntityFrameworkCore;
using TemplateApplication.Data;
using TemplateApplication.Models;
using TemplateApplication.Repository.Interface;

namespace TemplateApplication.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public async Task<List<UserDetail>> GetProducts()
        {
            return await _dbContext.UserDetail.ToListAsync();
        }

        public Task UpdateProduct(UserDetail product)
        {
            throw new NotImplementedException();
        }
    }
}
