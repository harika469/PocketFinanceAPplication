using System.Text.Json.Serialization;

namespace FinanceApp.Shared.Models.TickerDetails;

public class TickerDetailsDto
{
    public TickerDetailsDto()
    {
    }

    public TickerDetailsDto(TickerResultsDto? tickerResultsDto, string? status, string? requestId)
    {
        TickerResults = tickerResultsDto;
        Status = status;
        RequestId = requestId;
    }

    [JsonPropertyName("results")] public TickerResultsDto? TickerResults { get; set; } = null!;

    [JsonPropertyName("status")] public string? Status { get; set; } = null!;

    [JsonPropertyName("request_id")] public string? RequestId { get; set; } = null!;
}