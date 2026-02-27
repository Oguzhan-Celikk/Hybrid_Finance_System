using Microsoft.AspNetCore.Mvc;
using HybridFinanceSystem.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using HybridFinanceSystem.Infrastructure.Persistence;

namespace HybridFinanceSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return Ok(users);
    }
}

