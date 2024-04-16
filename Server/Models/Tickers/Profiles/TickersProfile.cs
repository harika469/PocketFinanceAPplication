using AutoMapper;
using FinanceApp.Shared.Models.TickerList;

namespace FinanceApp.Server.Models.Tickers.Profiles;

public class TickersProfile : Profile
{
    public TickersProfile()
    {
        CreateMap<TickerList, TickerListDto>();
        CreateMap<TickerListDto, TickerList>();

        CreateMap<TickerListItem, TickerListItemDto>();
        CreateMap<TickerListItemDto, TickerListItem>();
    }
}