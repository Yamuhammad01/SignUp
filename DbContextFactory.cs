using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SignUp.DbContext;
using System.IO;

public class DbContextFactory : IDesignTimeDbContextFactory<UsersDbContext>
{
    public UsersDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UsersDbContext>();

        // Build the configuration to read the appsettings.json file
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())  // Set base path to the directory of the current project
            .AddJsonFile("appsettings.json")               // Add appsettings.json for the connection string
            .Build();

        // Get the connection string from appsettings.json and configure the DbContext
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        // Return a new instance of the UsersDbContext with the configured options
        return new UsersDbContext(optionsBuilder.Options);
    }
}
