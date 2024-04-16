namespace FinanceApp.Shared.Models;

public class StockChartDataDto
{
    public StockChartDataDto()
    {
    }

    public StockChartDataDto(DateTime date, double open, double low, double close, double high, decimal volume)
    {
        Date = date;
        Open = open;
        Low = low;
        Close = close;
        High = high;
        Volume = volume;
    }

    public DateTime Date { get; set; }
    public double Open { get; set; }
    public double Low { get; set; }
    public double Close { get; set; }
    public double High { get; set; }
    public decimal Volume { get; set; }
}