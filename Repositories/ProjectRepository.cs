using Microsoft.EntityFrameworkCore;

namespace ProjectManagementAPI.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;
        public ProjectRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Project>> GetAllAsync() =>
            await _context.Projects.Include(p => p.Tasks).ToListAsync();

        public async Task<Project?> GetByIdAsync(int id) =>
            await _context.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Project> AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task UpdateAsync(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<ProjectTask> AddTaskAsync(int projectId, ProjectTask task)
        {
            task.ProjectId = projectId;
            _context.ProjectTasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<ProjectTask?> GetTaskByIdAsync(int id) =>
            await _context.ProjectTasks.FindAsync(id);

        public async Task UpdateTaskAsync(ProjectTask task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(ProjectTask task)
        {
            _context.ProjectTasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }

}
