using SignUp.Models;
using BCrypt.Net;
using SignUp.DTO;

namespace SignUp.Services
{
    public class UserService : IUserService
    {
        private readonly UsersDbContext _context;
        public UserService(UsersDbContext context)
        {
            _context = context;
        }
        public async Task<string> SignUpAsync(UsersDTO dto)
        {
            var user = new UserEntites
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            await _context.Users.AddAsync(user); 
            await _context.SaveChangesAsync();

            return $"User {dto.Username} signed up successfully!";
        }

    }

}
