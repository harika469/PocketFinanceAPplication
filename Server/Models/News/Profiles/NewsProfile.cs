using AutoMapper;
using FinanceApp.Shared.Models.News;

namespace FinanceApp.Server.Models.News.Profiles;

public class NewsProfile : Profile
{
    public NewsProfile()
    {
        CreateMap<NewsResultDto, NewsResult>();
        CreateMap<NewsResult, NewsResultDto>();

        CreateMap<PublisherDto, Publisher>();
        CreateMap<Publisher, PublisherDto>();
    }
}