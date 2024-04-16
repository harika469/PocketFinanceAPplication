using AutoMapper;
using FinanceApp.Shared.Models;

namespace FinanceApp.Server.Models.Logo;

public class LogoProfile : Profile
{
    public LogoProfile()
    {
        CreateMap<Logo, LogoDto>();
        CreateMap<LogoDto, Logo>();
    }
}