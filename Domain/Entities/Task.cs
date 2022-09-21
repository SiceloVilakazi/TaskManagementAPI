

namespace Domain.Entities
{
    public partial class Task
    {
        public Task()
        {
            DeletedTasks = new HashSet<DeletedTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime LastModifiedDateUtc { get; set; }

        public virtual TaskPriority Priority { get; set; } = null!;
        public virtual TaskStatus Status { get; set; } = null!;
        public virtual ICollection<DeletedTask> DeletedTasks { get; set; }
    }
}
