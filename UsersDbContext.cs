using SignUp.Models;
using Microsoft.EntityFrameworkCore;



namespace SignUp
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

        public DbSet<UserEntites> Users { get; set; } 


    }
}
