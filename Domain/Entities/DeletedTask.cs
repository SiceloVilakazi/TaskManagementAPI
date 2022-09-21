

namespace Domain.Entities
{
    public partial class DeletedTask
    {
        public int Id { get; set; }
        public int DeletedTaskId { get; set; }
        public int ReasonForDeletionId { get; set; }
        public int DeletionComment { get; set; }
        public DateTime DeletedDateUtc { get; set; }

        public virtual Task DeletedTaskNavigation { get; set; } = null!;
        public virtual DeletedReason ReasonForDeletion { get; set; } = null!;
    }
}
