namespace FinanceApp.Server.Models.News;

public class NewsImage
{
    public NewsImage(byte[] data, string? format, string idNews)
    {
        Data = data;
        Format = format;
        IdNews = idNews;
    }

    public virtual NewsResult NewsResult { get; set; } = null!;
    public string IdNews { get; set; }
    public byte[] Data { get; set; }
    public string? Format { get; set; }
}