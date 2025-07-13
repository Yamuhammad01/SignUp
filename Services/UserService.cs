using SignUp.DbContext;
using SignUp.Models;
using BCrypt.Net;

namespace SignUp.Services
{
    public class UserService : IUserService
    {
        private readonly UsersDbContext _context;
        public UserService(UsersDbContext context)
        {
            _context = context;
        }
        public async Task<string> SignUpAsync(UserEntites userInput)
        {
            // Hash the password before saving it to the database
            userInput.Password = BCrypt.Net.BCrypt.HashPassword(userInput.Password);

            // Set the Id to 0 to avoid any potential security issues

            userInput.Id = 0;
            // Add the user to the database
            _context.Users.Add(userInput);


            // Save changes to the database
            await _context.Users.SaveChangesAsync();
            await Task.Delay(100); // Simulated async operation
            return $"User {userInput.Username} signed up successfully!";
        }
    }

}
