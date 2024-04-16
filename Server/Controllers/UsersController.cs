using FinanceApp.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserDbService _userDbService;

    public UsersController(IUserDbService userDbService)
    {
        _userDbService = userDbService;
    }

    [HttpGet("{username}/watchlist-logos")]
    public async Task<IActionResult> GetWatchListLogosAsync(string username)
    {
        return Ok(await _userDbService.GetUserWatchlistLogosAsync(username));
    }

    [HttpGet("{username}/watching/{ticker}")]
    public async Task<IActionResult> IsWatchingAsync(string username, string ticker)
    {
        return await _userDbService.IsOnWatchListAsync(username, ticker) ? NoContent() : NotFound();
    }
}