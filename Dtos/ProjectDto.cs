using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPI.Dtos
{
    public class ProjectDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<TaskDto>? Tasks { get; set; }
    }

    public class TaskDto
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime DueDate { get; set; }


    }
    public class UpdateProjectDto
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }

}
