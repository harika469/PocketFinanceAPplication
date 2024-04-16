using FinanceApp.Shared.Models.TickerDetails;
using FinanceApp.Shared.Models.TickerList;

namespace FinanceApp.Server.Services.Interfaces;

public interface IUserDbService
{
    public Task<IEnumerable<TickerListItemDto>> GetUserWatchlistAsync(string username);
    public Task<IEnumerable<TickerResultsLogoDto>> GetUserWatchlistLogosAsync(string username);
    public Task<bool> IsOnWatchListAsync(string username, string ticker);
}