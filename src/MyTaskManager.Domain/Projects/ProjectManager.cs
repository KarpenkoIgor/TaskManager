using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace MyTaskManager.Projects
{
    public class ProjectManager : DomainService
    {
        
        private readonly IProjectRepository _projectRepository;
        
        public ProjectManager(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> CreateAsync(
            string projectName,
            string projectDescription,
            DateTime deadLine)
        {
            Check.NotNullOrWhiteSpace(projectName, nameof(projectName));

            var project = new Project(
                GuidGenerator.Create(),
                projectName,
                deadLine,
                projectDescription);

            return await _projectRepository.InsertAsync(project);
        }

    }
}
