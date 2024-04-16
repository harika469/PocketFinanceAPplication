namespace FinanceApp.Shared.Models.TickerDetails;

public class TickerResultsLogoDto
{
    public TickerResultsLogoDto(TickerResultsDto? tickerResultsDto, LogoDto? logoDto)
    {
        TickerResultsDto = tickerResultsDto;
        LogoDto = logoDto;
    }

    public TickerResultsDto? TickerResultsDto { get; set; }
    public LogoDto? LogoDto { get; set; }
}