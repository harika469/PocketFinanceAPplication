using System.Text.Json.Serialization;

namespace FinanceApp.Server.Models.News;

public class Publisher
{
#pragma warning disable CS8618
    public Publisher()
#pragma warning restore CS8618
    {
    }

    public Publisher(string name, string homepageUrl, string logoUrl, string? faviconUrl)
    {
        Name = name;
        HomepageUrl = homepageUrl;
        LogoUrl = logoUrl;
        FaviconUrl = faviconUrl;
    }

    public virtual ICollection<NewsResult> NewsResults { get; set; } = new HashSet<NewsResult>();

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("homepage_url")] public string HomepageUrl { get; set; }

    [JsonPropertyName("logo_url")] public string LogoUrl { get; set; }

    [JsonPropertyName("favicon_url")] public string? FaviconUrl { get; set; }
}