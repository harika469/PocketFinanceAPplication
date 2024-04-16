namespace FinanceApp.Shared.Models.News;

public class NewsResultImageDto
{
    public NewsResultImageDto(NewsResultDto newsResultDto, NewsImageDto? imageDto)
    {
        NewsResultDto = newsResultDto;
        ImageDto = imageDto;
    }

    public NewsResultDto NewsResultDto { get; set; }
    public NewsImageDto? ImageDto { get; set; }
}