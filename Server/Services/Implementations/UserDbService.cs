using AutoMapper;
using FinanceApp.Server.Data;
using FinanceApp.Server.Services.Interfaces;
using FinanceApp.Shared.Models;
using FinanceApp.Shared.Models.TickerDetails;
using FinanceApp.Shared.Models.TickerList;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Server.Services.Implementations;

public class UserDbService : IUserDbService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserDbService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TickerListItemDto>> GetUserWatchlistAsync(string username)
    {
        var watchlistFromDb = await _context.Users
            .Include(au => au.TickerWatchlist)
            .ToListAsync();
        return _mapper.Map<IEnumerable<TickerListItemDto>>(watchlistFromDb);
    }

    public async Task<IEnumerable<TickerResultsLogoDto>> GetUserWatchlistLogosAsync(string username)
    {
        return await _context.Users
            .Where(u => u.UserName == username)
            .Include(u => u.TickerWatchlist)
            .SelectMany(u => u.TickerWatchlist)
            .Select(tr => new TickerResultsLogoDto(
                _mapper.Map<TickerResultsDto>(tr),
                _mapper.Map<LogoDto>(tr.Logo))
            ).ToListAsync();
    }

    public async Task<bool> IsOnWatchListAsync(string username, string ticker)
    {
        return await _context.Users
            .Include(au => au.TickerWatchlist)
            .Where(au => au.UserName == username && au.TickerWatchlist.Select(t => t.Ticker).Contains(ticker))
            .AnyAsync();
    }
}