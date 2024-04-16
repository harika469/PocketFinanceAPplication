using System.Text.Json.Serialization;

namespace FinanceApp.Shared.Models.TickerList;

public class TickerListDto
{
    public TickerListDto(List<TickerListItemDto>? results, string? status, string? requestId, int? count,
        string? nextUrl)
    {
        Results = results;
        Status = status;
        RequestId = requestId;
        Count = count;
        NextUrl = nextUrl;
    }

    [JsonPropertyName("results")] public List<TickerListItemDto>? Results { get; set; }

    [JsonPropertyName("status")] public string? Status { get; set; }

    [JsonPropertyName("request_id")] public string? RequestId { get; set; }

    [JsonPropertyName("count")] public int? Count { get; set; }

    [JsonPropertyName("next_url")] public string? NextUrl { get; set; }
}