using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Dtos;
using ProjectManagementAPI.Repositories;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IProjectRepository _repo;
        private readonly IMapper _mapper;

        public TasksController(IProjectRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProjectTaskDto dto)
        {
            var existing = await _repo.GetTaskByIdAsync(id);
            if (existing == null) return NotFound();

            // Use AutoMapper to apply the update DTO to the existing entity
            _mapper.Map(dto, existing);
            await _repo.UpdateTaskAsync(existing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _repo.GetTaskByIdAsync(id);
            if (task == null) return NotFound();

            await _repo.DeleteTaskAsync(task);
            return NoContent();
        }
    }
}
