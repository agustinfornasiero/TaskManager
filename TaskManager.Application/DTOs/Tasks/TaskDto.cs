
namespace TaskManager.Application.DTOs.Tasks
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Descripion { get; set; } = string.Empty ;
        public Core.Enums.TaskStatus Status { get; set; }
        public Guid AssignedUserId { get; set; }
        public Guid CreatedByUserId { get; set; }
    }
}
