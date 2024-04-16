using FinanceApp.Shared.Models;
using FinanceApp.Shared.Models.News;
using FinanceApp.Shared.Models.TickerDetails;
using FinanceApp.Shared.Models.TickerList;

namespace FinanceApp.Server.Services.Interfaces;

public interface ITickerDbService
{
    public Task<IEnumerable<TickerListItemDto>> GetTickerListItemsAsync();
    public Task<int> SaveListItemsToDbAsync(IEnumerable<TickerListItemDto> tickerListItemDtos);

    public Task<TickerResultsDto?> GetTickerResultsAsync(string ticker);
    public Task<int> SaveResultsToDbAsync(TickerResultsDto tickerResultsDto);

    public Task<LogoDto?> GetLogoAsync(string ticker);
    public Task<int> UpdateLogoAsync(LogoDto logo);

    public Task<int> SubscribeToTickerAsync(string ticker, string username);
    public Task<int> UnsubscribeFromTickerAsync(string ticker, string username);

    public Task<DailyOpenCloseDto?> GetDailyOpenCloseAsync(string ticker, string from);
    public Task<int> SaveDailyOpenCloseToDbAsync(string ticker, DailyOpenCloseDto dailyOpenCloseDto);

    public Task<IEnumerable<StockChartDataDto>> GetStockChartDataAsync(string ticker, string timespan, int multiplier,
        DateTime queryDate, DateTime from, DateTime to);

    public Task<int> SaveStockChartDataAsync(IEnumerable<StockChartDataDto> stockChartDataDtoList, string ticker,
        string timespan, int multiplier, DateTime queryDate);

    public Task<int> SaveNewsImagesAsync(IEnumerable<NewsResultImageDto> resultImageDtos);
    public Task<IEnumerable<NewsResultImageDto>> GetNewsImagesAsync(string ticker, int count);
}