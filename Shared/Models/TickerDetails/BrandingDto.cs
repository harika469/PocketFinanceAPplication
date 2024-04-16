using System.Text.Json.Serialization;

namespace FinanceApp.Shared.Models.TickerDetails;

public class BrandingDto
{
    public BrandingDto(string? logoUrl, string? iconUrl)
    {
        LogoUrl = logoUrl;
        IconUrl = iconUrl;
    }

    [JsonPropertyName("logo_url")] public string? LogoUrl { get; set; }

    [JsonPropertyName("icon_url")] public string? IconUrl { get; set; }
}