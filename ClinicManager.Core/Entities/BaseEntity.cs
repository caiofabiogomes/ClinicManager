namespace ClinicManager.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        public Guid Id { get; private set; } = new Guid();

        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public DateTime? DeletedAt { get; private set; }

        public bool IsDeleted { get; private set; }

        public void Delete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.Now;
        }
    }
}
