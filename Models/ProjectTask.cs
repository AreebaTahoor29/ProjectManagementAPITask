﻿using System.ComponentModel.DataAnnotations;

public class ProjectTask
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime DueDate { get; set; }

    public int ProjectId { get; set; }

    public Project? Project { get; set; }
}
