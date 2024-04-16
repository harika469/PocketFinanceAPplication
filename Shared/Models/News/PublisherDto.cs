using System.Text.Json.Serialization;

namespace FinanceApp.Shared.Models.News;

public class PublisherDto
{
    public PublisherDto(string name, string homepageUrl, string logoUrl, string? faviconUrl)
    {
        Name = name;
        HomepageUrl = homepageUrl;
        LogoUrl = logoUrl;
        FaviconUrl = faviconUrl;
    }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("homepage_url")] public string HomepageUrl { get; set; }

    [JsonPropertyName("logo_url")] public string LogoUrl { get; set; }

    [JsonPropertyName("favicon_url")] public string? FaviconUrl { get; set; }
}