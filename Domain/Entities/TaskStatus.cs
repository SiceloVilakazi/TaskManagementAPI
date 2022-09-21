

namespace Domain.Entities
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public int Deleted { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
