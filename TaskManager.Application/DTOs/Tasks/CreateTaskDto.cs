
namespace TaskManager.Application.DTOs.Tasks
{
    public class CreateTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public Guid AssignedUserId { get; set; }
        public Guid CreatedByUserId { get; set; }
    }
}
