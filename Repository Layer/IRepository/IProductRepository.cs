using TemplateApplication.Models;

namespace TemplateApplication.Repository.Interface
{
    public interface IProductRepository
    {
        Task<List<UserDetail>> GetAllActiveUser();
        Task<UserDetail> GetUserById(int id);
        Task <bool> AddUser(UserDetail UserInfo);
        Task <bool> UpdateorDeleteUser(UserDetail UserInfo);

    }
}
