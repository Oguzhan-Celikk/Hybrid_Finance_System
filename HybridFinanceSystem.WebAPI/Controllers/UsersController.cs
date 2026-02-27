using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HybridFinanceSystem.Infrastructure.Persistence;

namespace HybridFinanceSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    // Dependency Injection: Program.cs'de tanıttığımız DbContext'i buraya istiyoruz
    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    // Tüm kullanıcıları getir (Test için)
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        // SQL: SELECT * FROM Users
        var users = await _context.Users.ToListAsync();
        
        if (users.Count == 0)
            return Ok("Veritabanı bağlantısı başarılı ama henüz kullanıcı yok.");

        return Ok(users);
    }
}

