
using TaskManager.Core.Common;
namespace TaskManager.Core.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; private set; } = string.Empty;
        public string? Description { get; private set; } = string.Empty;
        public Enums.TaskStatus Status { get; private set; }
        public Guid AssignedUserId { get; private set; }
        public Guid CreatedByUserId { get; set; }

        //Relación: Historial de Eventos. En Core la mantenemos como lista.
        private readonly List<TaskEvent> _events = new();

        public IReadOnlyCollection<TaskEvent> Events => _events.AsReadOnly();

        protected TaskItem() { }

        public TaskItem(string title, string? description, Guid createdByUserId, Guid assignedUserId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("El título es requerido.");

            if (createdByUserId == Guid.Empty)
                throw new DomainException("CreatedByUserId inválido.");

            if (assignedUserId == Guid.Empty)
                throw new DomainException("AssignedUserId inválido.");

            Title = title;
            Description = description;
            Status = Enums.TaskStatus.Pendiente;
            CreatedByUserId = createdByUserId;
            AssignedUserId = assignedUserId;
            AddEvent(new TaskEvent(Id, "Tarea Creada", null, assignedUserId, null, Status));

        }

        public void UpdateDetails(string title, string? description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("El título es requerido.");

            Title = title;
            Description = description;
            Touch();
            AddEvent(new TaskEvent(Id, "Detalles Actualizados."));

        }

        public void ChangeStatus(Enums.TaskStatus newStatus, Guid changeByUserId)
        {
            if (newStatus == Status)
                return;

            var oldStatus = Status;
            Status = newStatus;
            Touch();
            AddEvent(new TaskEvent(Id, $"Estado cambiado de {oldStatus} a {newStatus}.",
                fromUserId: changeByUserId, toUserId: changeByUserId, fromStatus: oldStatus, toStatus: newStatus));
        }

        public void Reassign(Guid newAssignedUserId, Guid changeByUserId)
        {
            if (newAssignedUserId == Guid.Empty)
                throw new DomainException("AssignedUserId inválido.");

            if (newAssignedUserId == AssignedUserId) return;

            var oldAssgnee = AssignedUserId;
            AssignedUserId = newAssignedUserId;
            Touch();
            AddEvent(new TaskEvent(Id, $"Tarea reasignada de {oldAssgnee} a {newAssignedUserId}.",
                fromUserId: changeByUserId, toUserId: newAssignedUserId));
        }

        private void AddEvent(TaskEvent evt)
        {
            _events.Add(evt);
        }

        //Método para que la infraestructura pueda vaciar o consumir eventos ya persistidos.
        public void ClearEvents() => _events.Clear();


    }
}
