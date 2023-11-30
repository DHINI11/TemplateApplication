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

        public async Task<List<UserDetail>> AddUser(UserDetail UserInfo)
        {
            
            var result = await _repository.AddUser(UserInfo);
            var data = await GetAllActiveUser();
            return data;

        }


        public Task<UserDetail> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDetail>> GetAllActiveUser()
        {
           return _repository.GetAllActiveUser();
        }

        public Task<bool> UpdateorDeleteUser(UserDetail UserInfo)
        {
            return _repository.UpdateorDeleteUser(UserInfo);
        }

        // Implement service methods
    }
}
