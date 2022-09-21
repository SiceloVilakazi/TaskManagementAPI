using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class TaskPriority
    {
        public TaskPriority()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Priority { get; set; } = null!;
        public int Deleted { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
