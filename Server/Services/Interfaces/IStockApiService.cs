using FinanceApp.Server.Models.Tickers;
using FinanceApp.Shared.Models;
using FinanceApp.Shared.Models.News;
using FinanceApp.Shared.Models.TickerDetails;
using FinanceApp.Shared.Models.TickerList;

namespace FinanceApp.Server.Services.Interfaces;

public interface IStockApiService
{
    public Task<List<TickerListItemDto>?> GetTickerList();
    public Task<TickerDetailsDto?> GetTickerDetails(string ticker);
    public Task<LogoDto?> GetLogoAsync(TickerResultsDto tickerResultsDto);
    public Task<DailyOpenCloseDto?> GetDailyOpenCloseAsync(string ticker, string from);
    public Task<IEnumerable<StockChartDataDto>> GetChartData(string ticker, string timespan, int multiplier,
        long fromUnix, long toUnix);

    public Task<IEnumerable<NewsResultImageDto>> GetNewsAsync(string ticker, int count);
}