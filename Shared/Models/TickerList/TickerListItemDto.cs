using System.Text.Json.Serialization;

namespace FinanceApp.Shared.Models.TickerList;

public class TickerListItemDto
{
    public TickerListItemDto(string ticker, string name, string market, string locale, string? primaryExchange,
        string? type, bool? active, string? currencyName, string? cik, string? compositeFigi, string? shareClassFigi,
        DateTime? lastUpdatedUtc)
    {
        Ticker = ticker;
        Name = name;
        Market = market;
        Locale = locale;
        PrimaryExchange = primaryExchange;
        Type = type;
        Active = active;
        CurrencyName = currencyName;
        Cik = cik;
        CompositeFigi = compositeFigi;
        ShareClassFigi = shareClassFigi;
        LastUpdatedUtc = lastUpdatedUtc;
    }

    [JsonPropertyName("ticker")] public string Ticker { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("market")] public string Market { get; set; }

    [JsonPropertyName("locale")] public string Locale { get; set; }

    [JsonPropertyName("primary_exchange")] public string? PrimaryExchange { get; set; }

    [JsonPropertyName("type")] public string? Type { get; set; }

    [JsonPropertyName("active")] public bool? Active { get; set; }

    [JsonPropertyName("currency_name")] public string? CurrencyName { get; set; }

    [JsonPropertyName("cik")] public string? Cik { get; set; }

    [JsonPropertyName("composite_figi")] public string? CompositeFigi { get; set; }

    [JsonPropertyName("share_class_figi")] public string? ShareClassFigi { get; set; }

    [JsonPropertyName("last_updated_utc")] public DateTime? LastUpdatedUtc { get; set; }
}