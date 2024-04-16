using FinanceApp.Server.Models.TickerDetails;

namespace FinanceApp.Server.Models.Logo;

public class Logo
{
    public Logo(string ticker, byte[] data, string format)
    {
        Ticker = ticker;
        Data = data;
        Format = format;
    }

    public string Ticker { get; set; }
    public byte[] Data { get; set; }
    public string Format { get; set; }
    public virtual TickerResults TickerResults { get; set; } = null!;
}