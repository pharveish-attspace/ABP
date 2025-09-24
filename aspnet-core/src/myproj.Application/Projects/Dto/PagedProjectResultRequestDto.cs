using Abp.Application.Services.Dto;

namespace myproj.Projects.Dto
{
    public class PagedProjectResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

