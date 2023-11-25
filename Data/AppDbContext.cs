using Microsoft.EntityFrameworkCore;
using TemplateApplication.Models;

namespace TemplateApplication.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserDetail>  UserDetail { get; set; }
    }



}
