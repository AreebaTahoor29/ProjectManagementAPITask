using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPI.Dtos
{
    public class ProjectTaskDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime DueDate { get; set; }
    }
    public class UpdateProjectTaskDto
    {
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        public bool? IsCompleted { get; set; }

        public DateTime? DueDate { get; set; }
    }

}
