using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Reflection;
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

        public async Task<bool> AddUser(UserDetail UserInfo)
        {
            var Data = new UserDetail();

            try
            {
                if (UserInfo != null)
                {
                    Data.UserName = UserInfo.UserName;
                    Data.Email = UserInfo.Email;
                    Data.Phone = UserInfo.Phone;
                    Data.IsDeleted = false;
                    Data.UserRoll = 2;
                    Data.CreatedOn = DateTime.Now;
                    Data.UpdatedOn = null;

                    await _dbContext.UserDetail.AddAsync(Data);
                    await _dbContext.SaveChangesAsync();

                    return true;
                }
                else {
                    return false;
                }

            }
            catch {

                return false;

            }
            
        }

        public async Task<List<UserDetail>> GetAllActiveUser()
        {
            return await _dbContext.UserDetail.Where(OO=>OO.IsDeleted == false).ToListAsync();
        }

        public async Task<bool> UpdateorDeleteUser(UserDetail UserInfo)
        {
            try
            {
                var User = await _dbContext.UserDetail.FindAsync(UserInfo.ID);
                if (User == null)
                    return false;

                if (UserInfo.IsDeleted)
                {
                    User.IsDeleted = true;
                    User.UpdatedOn = DateTime.Now;
                }
                else
                {
                    User.UserName = UserInfo.UserName;
                    User.Email = UserInfo.Email;
                    User.Phone = UserInfo.Phone;
                    User.UpdatedOn= DateTime.Now;
                }

                await _dbContext.SaveChangesAsync();

                return true;

            }
            catch 
            {
                return false;
            
            }
            

        }

        public Task<UserDetail> GetUserById(int id)
        {
            //TO DO
            throw new NotImplementedException();
        }
    }
}
