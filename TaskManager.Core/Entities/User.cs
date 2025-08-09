using TaskManager.Core.Common;

namespace TaskManager.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        //Constructor para EF sin Parámetros
        protected User() { }

        public User(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("El nombre de usuario es requerido.");

            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("El email es requerido.");

            //ToDo Agregar Validación campo Email.

            Name = name;
            Email = email;
        }

        public void Update(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("El nombre de usuario es requerido.");

            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("El email es requerido.");

            //ToDo Agregar Validación campo Email.

            Name = name;
            Email = email;
            Touch();
        }
    }
}
