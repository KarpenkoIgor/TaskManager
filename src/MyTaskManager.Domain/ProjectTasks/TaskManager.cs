using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace MyTaskManager.ProjectTasks
{
    public class TaskManager : DomainService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskManager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProjectUserId { get; set; }
        public DateTime DeadLine { get; set; }
        public bool IsClosed { get; set; }
        public async Task<ProjectTask> CreateAsync(
            string taskName,
            Guid projectUserId,
            DateTime deadLine,
            string taskDescription)
        {
            Check.NotNullOrWhiteSpace(taskName, nameof(taskName));

            var task = new ProjectTask(
                GuidGenerator.Create(),
                taskName,
                projectUserId,
                deadLine,
                taskDescription
            );

            return await _taskRepository.InsertAsync(task);
        }

        public async Task<List<ProjectTask>> GetListAsync()
        {
            return await _taskRepository.GetListAsync();
        }
        public async Task<ProjectTask> GetAsync(Guid id)
        {
            return await _taskRepository.GetAsync(id);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _taskRepository.DeleteAsync(id);
        }
        public async Task UpdateAsync(ProjectTask task) 
        {
            await _taskRepository.UpdateAsync(task);
        }
        public async Task<long> GetCountAsync()
        {
            return await _taskRepository.GetCountAsync();
        }
    }
}
