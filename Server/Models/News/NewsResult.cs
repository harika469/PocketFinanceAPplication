using System.Text.Json.Serialization;
using FinanceApp.Server.Models.TickerDetails;

namespace FinanceApp.Server.Models.News;

public class NewsResult
{
#pragma warning disable CS8618
    public NewsResult()
#pragma warning restore CS8618
    {
    }

    public NewsResult(string publisherName, NewsImage? newsImage, string idNews, Publisher publisher, string title,
        string author, DateTime publishedUtc, string articleUrl, string? description)
    {
        PublisherName = publisherName;
        NewsImage = newsImage;
        IdNews = idNews;
        Publisher = publisher;
        Title = title;
        Author = author;
        PublishedUtc = publishedUtc;
        ArticleUrl = articleUrl;
        Description = description;
    }

    public virtual ICollection<TickerResults> TickerResults { get; set; } = new HashSet<TickerResults>();

    public string PublisherName { get; set; }
    public NewsImage? NewsImage { get; set; }

    [JsonPropertyName("id")] public string IdNews { get; set; }

    [JsonPropertyName("publisher")] public Publisher Publisher { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }

    [JsonPropertyName("author")] public string Author { get; set; }

    [JsonPropertyName("published_utc")] public DateTime PublishedUtc { get; set; }

    [JsonPropertyName("article_url")] public string ArticleUrl { get; set; }

    [JsonPropertyName("description")] public string? Description { get; set; }
}