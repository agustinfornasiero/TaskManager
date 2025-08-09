using TaskManager.Core.Common;
using TaskManager.Core.Enums;

namespace TaskManager.Core.Entities
{
    public class TaskEvent : BaseEntity
    {
        public Guid TaskId { get; private set; }
        public DateTime OcurredAt { get; private set; } = DateTime.UtcNow;
        public string Description { get; private set; } = string.Empty;
        public Guid? FromUserId { get; private set; }
        public Guid? ToUserId { get; private set; }
        public Enums.TaskStatus? FromStatus { get; private set; }
        public Enums.TaskStatus? ToStatus { get; private set; }

        protected TaskEvent() { }

        public TaskEvent(Guid taskId, string description, Guid? fromUserId = null, Guid? toUserId = null,
            Enums.TaskStatus? fromStatus = null, Enums.TaskStatus? toStatus = null) 
        {
            TaskId = taskId;
            Description = description;
            FromUserId = fromUserId;
            ToUserId = toUserId;
            FromStatus = fromStatus;
            ToStatus = toStatus;
        }
    }
}
