using Abp.Application.Services;
using myproj.Projects.Dto;
using Abp.Domain.Repositories;
using System.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using System.Threading.Tasks;
using Abp.Authorization;
using myproj.Authorization;

namespace myproj.Projects
{
    [AbpAuthorize(PermissionNames.Pages_Projects)]
    public class ProjectAppService : AsyncCrudAppService<Project, ProjectDto, long, PagedProjectResultRequestDto, CreateProjectDto, ProjectDto>
    {

        public ProjectAppService(IRepository<Project, long> repository) : base(repository)
        {
            
        }

        protected override IQueryable<Project> CreateFilteredQuery(PagedProjectResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Title.Contains(input.Keyword)
                || x.Description.Contains(input.Keyword));
        }

    }
}