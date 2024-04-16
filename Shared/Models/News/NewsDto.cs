using System.Text.Json.Serialization;

namespace FinanceApp.Shared.Models.News;

public class NewsDto
{
    [JsonPropertyName("results")] public List<NewsResultDto>? Results { get; set; }

    [JsonPropertyName("status")] public string? Status { get; set; }

    [JsonPropertyName("request_id")] public string? RequestId { get; set; }

    [JsonPropertyName("count")] public int? Count { get; set; }

    [JsonPropertyName("next_url")] public string? NextUrl { get; set; }
}