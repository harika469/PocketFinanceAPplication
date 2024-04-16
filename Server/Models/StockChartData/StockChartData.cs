using FinanceApp.Server.Models.TickerDetails;

namespace FinanceApp.Server.Models.StockChartData;

public class StockChartData
{
    public StockChartData()
    {
    }

    public StockChartData(string ticker, string timespan, int multiplier, DateTime queryDate, DateTime date,
        double open, double low,
        double close, double high, decimal volume)
    {
        Ticker = ticker;
        Timespan = timespan;
        Multiplier = multiplier;
        QueryDate = queryDate;
        Date = date;
        Open = open;
        Low = low;
        Close = close;
        High = high;
        Volume = volume;
    }

    public virtual TickerResults TickerResults { get; set; } = null!;
    public string Ticker { get; set; } = null!;
    public string Timespan { get; set; } = null!;
    public int Multiplier { get; set; }
    public DateTime QueryDate { get; set; }
    public DateTime Date { get; set; }
    public double Open { get; set; }
    public double Low { get; set; }
    public double Close { get; set; }
    public double High { get; set; }
    public decimal Volume { get; set; }
}