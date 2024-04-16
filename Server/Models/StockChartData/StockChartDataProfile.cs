using AutoMapper;
using FinanceApp.Shared.Models;

namespace FinanceApp.Server.Models.StockChartData;

public class StockChartDataProfile : Profile
{
    public StockChartDataProfile()
    {
        CreateMap<StockChartData, StockChartDataDto>();
        CreateMap<StockChartDataDto, StockChartData>();
    }
}