namespace ProjectManagementAPI.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(int id);
        Task<Project> AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Project project);
        Task<ProjectTask> AddTaskAsync(int projectId, ProjectTask task);
        Task<ProjectTask?> GetTaskByIdAsync(int id);
        Task UpdateTaskAsync(ProjectTask task);
        Task DeleteTaskAsync(ProjectTask task);
    }

}
