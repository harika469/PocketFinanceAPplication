using System.Text.Json.Serialization;

namespace FinanceApp.Shared.Models.TickerDetails;

public class TickerResultsDto
{
    public TickerResultsDto(string ticker, string name, string market, string locale, string? primaryExchange, string type, bool active, string currencyName, string? cik, string? compositeFigi, string? shareClassFigi, double? marketCap, string? phoneNumber, AddressDto? address, string? description, string? sicCode, string? sicDescription, string? tickerRoot, string? homepageUrl, int? totalEmployees, string? listDate, BrandingDto? branding, long? shareClassSharesOutstanding, long? weightedSharesOutstanding)
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
        MarketCap = marketCap;
        PhoneNumber = phoneNumber;
        Address = address;
        Description = description;
        SicCode = sicCode;
        SicDescription = sicDescription;
        TickerRoot = tickerRoot;
        HomepageUrl = homepageUrl;
        TotalEmployees = totalEmployees;
        ListDate = listDate;
        Branding = branding;
        ShareClassSharesOutstanding = shareClassSharesOutstanding;
        WeightedSharesOutstanding = weightedSharesOutstanding;
    }

    [JsonPropertyName("ticker")] public string Ticker { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("market")] public string Market { get; set; }

    [JsonPropertyName("locale")] public string Locale { get; set; }

    [JsonPropertyName("primary_exchange")] public string? PrimaryExchange { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("active")] public bool Active { get; set; }

    [JsonPropertyName("currency_name")] public string CurrencyName { get; set; }

    [JsonPropertyName("cik")] public string? Cik { get; set; }

    [JsonPropertyName("composite_figi")] public string? CompositeFigi { get; set; }

    [JsonPropertyName("share_class_figi")] public string? ShareClassFigi { get; set; }

    [JsonPropertyName("market_cap")] public double? MarketCap { get; set; }

    [JsonPropertyName("phone_number")] public string? PhoneNumber { get; set; }

    [JsonPropertyName("address")] public AddressDto? Address { get; set; }

    [JsonPropertyName("description")] public string? Description { get; set; }

    [JsonPropertyName("sic_code")] public string? SicCode { get; set; }

    [JsonPropertyName("sic_description")] public string? SicDescription { get; set; }

    [JsonPropertyName("ticker_root")] public string? TickerRoot { get; set; }

    [JsonPropertyName("homepage_url")] public string? HomepageUrl { get; set; }

    [JsonPropertyName("total_employees")] public int? TotalEmployees { get; set; }

    [JsonPropertyName("list_date")] public string? ListDate { get; set; }

    [JsonPropertyName("branding")] public BrandingDto? Branding { get; set; }

    [JsonPropertyName("share_class_shares_outstanding")]
    public long? ShareClassSharesOutstanding { get; set; }

    [JsonPropertyName("weighted_shares_outstanding")]
    public long? WeightedSharesOutstanding { get; set; }
}