using Microsoft.AspNetCore.Mvc;
using SignUp.DTO;
using SignUp.Models;
using SignUp.Services;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] UsersDTO userInput)
    {
        if (string.IsNullOrWhiteSpace(userInput.Username) ||
            string.IsNullOrWhiteSpace(userInput.Email) ||
            string.IsNullOrWhiteSpace(userInput.Password))
        {
            return BadRequest(new { Success = false, Message = "All fields are required." });
        }

        var result = await _userService.SignUpAsync(userInput);
        return Ok(new { Success = true, Message = result });
    }
}
