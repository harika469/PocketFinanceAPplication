using System.Text.Json.Serialization;

namespace FinanceApp.Shared.Models.News;

public class NewsResultDto
{
#pragma warning disable CS8618
    public NewsResultDto()
#pragma warning restore CS8618
    {
    }

    public NewsResultDto(string idNews, PublisherDto publisher, string title, string author, DateTime publishedUtc,
        string articleUrl, List<string> tickers, string? imageUrl, string? description, List<string>? keywords,
        string? ampUrl)
    {
        IdNews = idNews;
        Publisher = publisher;
        Title = title;
        Author = author;
        PublishedUtc = publishedUtc;
        ArticleUrl = articleUrl;
        Tickers = tickers;
        ImageUrl = imageUrl;
        Description = description;
        Keywords = keywords;
        AmpUrl = ampUrl;
    }

    [JsonPropertyName("id")] public string IdNews { get; set; }

    [JsonPropertyName("publisher")] public PublisherDto Publisher { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }

    [JsonPropertyName("author")] public string Author { get; set; }

    [JsonPropertyName("published_utc")] public DateTime PublishedUtc { get; set; }

    [JsonPropertyName("article_url")] public string ArticleUrl { get; set; }

    [JsonPropertyName("tickers")] public List<string> Tickers { get; set; }

    [JsonPropertyName("image_url")] public string? ImageUrl { get; set; }

    [JsonPropertyName("description")] public string? Description { get; set; }

    [JsonPropertyName("keywords")] public List<string>? Keywords { get; set; }

    [JsonPropertyName("amp_url")] public string? AmpUrl { get; set; }
}