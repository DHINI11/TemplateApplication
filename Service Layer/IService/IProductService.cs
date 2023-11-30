using TemplateApplication.Models;

namespace TemplateApplication.Service.Interface
{
    public interface IProductService
    {
        Task<List<UserDetail>> GetAllActiveUser();
        Task<UserDetail> GetProductById(int id);
        Task<List<UserDetail>> AddUser(UserDetail UserInfo);
        Task <bool> UpdateorDeleteUser(UserDetail UserInfo);
    }

}
