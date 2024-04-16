using System.Text.Json.Serialization;

namespace FinanceApp.Shared.Models;

public class DailyOpenCloseDto
{
    public DailyOpenCloseDto(string? status, string? from, string? symbol, double? open, double? high, double? low, double? close, decimal? volume, double? afterHours, double? preMarket)
    {
        Status = status;
        From = from;
        Symbol = symbol;
        Open = open;
        High = high;
        Low = low;
        Close = close;
        Volume = volume;
        AfterHours = afterHours;
        PreMarket = preMarket;
    }

    [JsonPropertyName("status")] public string? Status { get; set; }

    [JsonPropertyName("from")] public string? From { get; set; }

    [JsonPropertyName("symbol")] public string? Symbol { get; set; }

    [JsonPropertyName("open")] public double? Open { get; set; }

    [JsonPropertyName("high")] public double? High { get; set; }

    [JsonPropertyName("low")] public double? Low { get; set; }

    [JsonPropertyName("close")] public double? Close { get; set; }

    [JsonPropertyName("volume")] public decimal? Volume { get; set; }

    [JsonPropertyName("afterHours")] public double? AfterHours { get; set; }

    [JsonPropertyName("preMarket")] public double? PreMarket { get; set; }
}