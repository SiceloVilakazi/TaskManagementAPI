namespace Domain.Entities
{
    public partial class DeletedReason
    {
        public DeletedReason()
        {
            DeletedTasks = new HashSet<DeletedTask>();
        }

        public int Id { get; set; }
        public string Reason { get; set; } = null!;
        public int Deleted { get; set; }

        public virtual ICollection<DeletedTask> DeletedTasks { get; set; }
    }
}
