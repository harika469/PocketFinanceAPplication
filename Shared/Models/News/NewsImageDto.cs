namespace FinanceApp.Shared.Models.News;

public class NewsImageDto
{
    public NewsImageDto(byte[] data, string? format)
    {
        Data = data;
        Format = format;
    }

    public byte[] Data { get; set; }
    public string? Format { get; set; }
}