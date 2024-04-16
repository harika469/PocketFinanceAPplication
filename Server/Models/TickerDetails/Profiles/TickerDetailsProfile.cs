using AutoMapper;
using FinanceApp.Shared.Models.TickerDetails;

namespace FinanceApp.Server.Models.TickerDetails.Profiles;

public class TickerDetailsProfile : Profile
{
    public TickerDetailsProfile()
    {
        CreateMap<Branding, BrandingDto>();
        CreateMap<BrandingDto, Branding>();

        CreateMap<Address, AddressDto>();
        CreateMap<AddressDto, Address>();

        CreateMap<TickerResultsDto, TickerResults>();
        CreateMap<TickerResults, TickerResultsDto>();
    }
}