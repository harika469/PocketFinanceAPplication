using FinanceApp.Server.Models.Bars;
using FinanceApp.Server.Models.Tickers;
using FinanceApp.Server.Services.Interfaces;
using FinanceApp.Shared.Models;
using FinanceApp.Shared.Models.News;
using FinanceApp.Shared.Models.TickerDetails;
using FinanceApp.Shared.Models.TickerList;

namespace FinanceApp.Server.Services.Implementations;

public class PolygonApiService : IStockApiService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;

    public PolygonApiService(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }

    public async Task<List<TickerListItemDto>?> GetTickerList()
    {
        var allTickers = new List<TickerListItemDto>();

        var tickerListDto = await _clientFactory.CreateClient()
            .GetFromJsonAsync<TickerListDto>(
                "https://api.polygon.io/v3/reference/tickers?type=CS" +
                "&market=stocks&exchange=XNAS" +
                "&active=true&sort=ticker" +
                "&order=asc" +
                "&limit=1000" +
                $"&apiKey={_configuration["Polygon:ApiKey"]}");

        var nextUrl = tickerListDto?.NextUrl;

        if (tickerListDto?.Results == null) return allTickers;

        allTickers.AddRange(tickerListDto.Results!);

        while (!string.IsNullOrEmpty(nextUrl))
        {
            tickerListDto = await _clientFactory.CreateClient()
                .GetFromJsonAsync<TickerListDto>(
                    $"{nextUrl}" +
                    $"&apiKey={_configuration["Polygon:ApiKey"]}");
            allTickers.AddRange(tickerListDto!.Results!);
            nextUrl = tickerListDto.NextUrl;
        }

        return allTickers;
    }

    public async Task<TickerDetailsDto?> GetTickerDetails(string ticker)
    {
        return await _clientFactory.CreateClient()
            .GetFromJsonAsync<TickerDetailsDto>(
                $"https://api.polygon.io/v3/reference/tickers/{ticker}" +
                $"?apiKey={_configuration["Polygon:ApiKey"]}");
    }

    public async Task<LogoDto?> GetLogoAsync(TickerResultsDto tickerResultsDto)
    {
        if (tickerResultsDto.Branding?.LogoUrl == null) return null;
        var logoArray = await _clientFactory.CreateClient()
            .GetByteArrayAsync(
                $"{tickerResultsDto.Branding.LogoUrl}" +
                $"?apiKey={_configuration["Polygon:ApiKey"]}");
        var logoFormat = Path.GetExtension(tickerResultsDto.Branding.LogoUrl)[1..];
        return new LogoDto(tickerResultsDto.Ticker, logoArray, logoFormat);
    }

    public async Task<DailyOpenCloseDto?> GetDailyOpenCloseAsync(string ticker, string from)
    {
        return await _clientFactory.CreateClient()
            .GetFromJsonAsync<DailyOpenCloseDto>(
                $"https://api.polygon.io/v1/open-close/{ticker}/{from}" +
                $"?apiKey={_configuration["Polygon:ApiKey"]}");
    }
 
    public async Task<IEnumerable<StockChartDataDto>> GetChartData(string ticker, string timespan, int multiplier,
        long fromOffsetAdjustedUnix, long toOffsetAdjustedUnix)
    {
        var bars = await _clientFactory.CreateClient()
            .GetFromJsonAsync<Bars>(
                $"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/{multiplier}/{timespan}/{fromOffsetAdjustedUnix}/{toOffsetAdjustedUnix}" +
                "?adjusted=true" +
                "&sort=asc" +
                "&limit=5000" +
                $"&apiKey={_configuration["Polygon:ApiKey"]}");

        var chartDataDtoList = new List<StockChartDataDto>();
        if (bars?.Results == null) return chartDataDtoList;

        var date = DateTimeOffset.FromUnixTimeMilliseconds(fromOffsetAdjustedUnix);
        foreach (var result in bars.Results)
        {
            // skip weekends
            date = date.DayOfWeek switch
            {
                DayOfWeek.Saturday => date.AddDays(2),
                DayOfWeek.Sunday => date.AddDays(1),
                _ => date
            };

            chartDataDtoList.Add(new StockChartDataDto
            {
                Date = date.DateTime,
                Open = result.O,
                Low = result.L,
                Close = result.C,
                High = result.H,
                Volume = result.V
            });

            date = timespan switch
            {
                "minute" => date.AddMinutes(multiplier),
                "hour" => date.AddHours(multiplier),
                "day" => date.AddDays(multiplier),
                "week" => date.AddDays(7 * multiplier),
                _ => date
            };
        }

        return chartDataDtoList;
    }


    public async Task<IEnumerable<NewsResultImageDto>> GetNewsAsync(string ticker, int count)
    {
        var client = _clientFactory.CreateClient();
        var newsDto = await client.GetFromJsonAsync<NewsDto>(
            "https://api.polygon.io/v2/reference/news" +
            $"?ticker={ticker}" +
            $"&limit={count}" +
            $"&apiKey={_configuration["Polygon:ApiKey"]}");

        var resultsImagesDtoList = new List<NewsResultImageDto>();
        if (newsDto?.Results == null) return resultsImagesDtoList;

        foreach (var resultDto in newsDto.Results)
        {
            NewsImageDto? newsImageDto = null;
            if (resultDto.ImageUrl != null)
            {
                try
                {
                    var image = await client.GetByteArrayAsync(resultDto.ImageUrl);
                    string? format;
                    try
                    {
                        format = Path.GetExtension(resultDto.ImageUrl)[1..];
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        format = null;
                        Console.WriteLine("No image format specified");
                    }

                    newsImageDto = new NewsImageDto(image, format);
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine("Unable to get news image");
                }
            }

            resultsImagesDtoList.Add(new NewsResultImageDto(resultDto, newsImageDto));
        }

        return resultsImagesDtoList;
    }
}