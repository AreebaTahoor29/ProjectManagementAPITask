using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Dtos;
using ProjectManagementAPI.Repositories;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _repo;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _repo.GetByIdAsync(id);
            return project == null ? NotFound() : Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var project = _mapper.Map<Project>(dto);
            var created = await _repo.AddAsync(project);

            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProjectDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing); // update in-place

            await _repo.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _repo.GetByIdAsync(id);
            if (project == null) return NotFound();

            await _repo.DeleteAsync(project);
            return NoContent();
        }

        [HttpPost("{projectId}/tasks")]
        public async Task<IActionResult> AddTask(int projectId, ProjectTaskDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var task = _mapper.Map<ProjectTask>(dto);
            task.ProjectId = projectId;

            var created = await _repo.AddTaskAsync(projectId, task);
            return Ok(created);
        }
    }
}
