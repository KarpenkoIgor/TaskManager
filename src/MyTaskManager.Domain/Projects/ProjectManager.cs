﻿using Scriban.Runtime.Accessors;
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

        public async Task<List<Project>> GetListProjectsAsync() 
        {
            return await _projectRepository.GetListAsync();
        }
        public async Task<Project> GetAsync(Guid id)
        {
            return await _projectRepository.GetAsync(id);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _projectRepository.DeleteAsync(id);
        }
        public async Task UpdateAsync(Project project)
        {
            await _projectRepository.UpdateAsync(project);
        }
        public async Task<long> GetCountAsync()
        {
            return await _projectRepository.GetCountAsync();
        }

    }
}
