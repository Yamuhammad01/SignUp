using SignUp.Models;

namespace SignUp.Services
{
    public interface IUserService
    {
        Task<string> SignUpAsync(UserEntites userInput);
    }
}
