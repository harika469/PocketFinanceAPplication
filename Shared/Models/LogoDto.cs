namespace FinanceApp.Shared.Models;

public class LogoDto
{
    public LogoDto(string ticker, byte[] data, string format)
    {
        Ticker = ticker;
        Data = data;
        Format = format;
    }

    public string Ticker { get; set; }
    public byte[] Data { get; set; }
    public string Format { get; set; }
}