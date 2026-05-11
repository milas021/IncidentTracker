using IncidentTracker.Application.DTOs.Users;
using IncidentTracker.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncidentTracker.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController(UserService userService) : AppController {
    [HttpPost]
    public async Task<IActionResult> AddUser(AddUserCommand commnad) {
        await userService.Add(commnad);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var result = await userService.GetAll();
        return Ok(result);


    }
}
