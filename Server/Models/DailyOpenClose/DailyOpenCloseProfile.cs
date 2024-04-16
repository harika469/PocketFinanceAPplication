using AutoMapper;
using FinanceApp.Shared.Models;

namespace FinanceApp.Server.Models.DailyOpenClose;

public class DailyOpenCloseProfile : Profile
{
    public DailyOpenCloseProfile()
    {
        CreateMap<DailyOpenClose, DailyOpenCloseDto>();
        CreateMap<DailyOpenCloseDto, DailyOpenClose>();
    }
}