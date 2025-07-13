using Microsoft.EntityFrameworkCore;
using SignUp.Models;
namespace SignUp.DbContext
{
    

    public class UsersDbContext : DbContext
    {
        public DbSet<UserEntites> Users { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }
    }

}
