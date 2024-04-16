using System.Text.Json.Serialization;

namespace FinanceApp.Server.Models.TickerDetails;

public class Branding
{
    public Branding()
    {
    }

    public Branding(string logoUrl, string iconUrl)
    {
        LogoUrl = logoUrl;
        IconUrl = iconUrl;
    }

    [JsonPropertyName("logo_url")] public string LogoUrl { get; set; } = null!;

    [JsonPropertyName("icon_url")] public string? IconUrl { get; set; }
}