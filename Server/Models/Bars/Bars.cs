using System.Text.Json.Serialization;

namespace FinanceApp.Server.Models.Bars;

public class Bars
{
    public Bars(string ticker, int queryCount, int resultsCount, bool adjusted, List<BarsResult> results, string status,
        string requestId, int count)
    {
        Ticker = ticker;
        QueryCount = queryCount;
        ResultsCount = resultsCount;
        Adjusted = adjusted;
        Results = results;
        Status = status;
        RequestId = requestId;
        Count = count;
    }

    [JsonPropertyName("ticker")] public string Ticker { get; set; }

    [JsonPropertyName("queryCount")] public int QueryCount { get; set; }

    [JsonPropertyName("resultsCount")] public int ResultsCount { get; set; }

    [JsonPropertyName("adjusted")] public bool Adjusted { get; set; }

    [JsonPropertyName("results")] public List<BarsResult> Results { get; set; }

    [JsonPropertyName("status")] public string Status { get; set; }

    [JsonPropertyName("request_id")] public string RequestId { get; set; }

    [JsonPropertyName("count")] public int Count { get; set; }
}