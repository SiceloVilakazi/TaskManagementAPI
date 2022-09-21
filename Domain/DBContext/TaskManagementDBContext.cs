using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Domain.DBContext
{
    /// <summary>
    /// Task Management system database context
    /// </summary>
    public partial class TaskManagementDBContext : DbContext
    {

        #region commented code
        /// <summary>
        /// Initializes constructor
        /// </summary>
        // public TaskManagementDBContext()
        // {
        // }
        #endregion

        /// <summary>
        /// Initializes constructor
        /// </summary>
        /// <param name="options"></param>
        public TaskManagementDBContext(DbContextOptions<TaskManagementDBContext> options)
            : base(options)
        {
        }

        #region DB Sets
        public virtual DbSet<DeletedReason> DeletedReasons { get; set; } = null!;
        public virtual DbSet<DeletedTask> DeletedTasks { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskPriority> TaskPriorities { get; set; } = null!;
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; } = null!;

        #endregion

        #region Options builder Configuring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
        #endregion

        #region On model creation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeletedReason>(entity =>
            {
                entity.ToTable("DeletedReason");

                entity.Property(e => e.Reason).HasMaxLength(50);
            });

            modelBuilder.Entity<DeletedTask>(entity =>
            {
                entity.ToTable("DeletedTask");

                entity.Property(e => e.DeletedDateUtc).HasColumnName("DeletedDateUTC");

                entity.HasOne(d => d.DeletedTaskNavigation)
                    .WithMany(p => p.DeletedTasks)
                    .HasForeignKey(d => d.DeletedTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_DeletedTaskId");

                entity.HasOne(d => d.ReasonForDeletion)
                    .WithMany(p => p.DeletedTasks)
                    .HasForeignKey(d => d.ReasonForDeletionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeletedReason_DeletedReasonId");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.CreatedDateUtc).HasColumnName("CreatedDateUTC");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EndDateUtc).HasColumnName("EndDateUTC");

                entity.Property(e => e.LastModifiedDateUtc).HasColumnName("LastModifiedDateUTC");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StartDateUtc).HasColumnName("StartDateUTC");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.PriorityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Priority_PriorityId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_StatusId");
            });

            modelBuilder.Entity<TaskPriority>(entity =>
            {
                entity.ToTable("TaskPriority");

                entity.Property(e => e.Priority).HasMaxLength(50);
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.ToTable("TaskStatus");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #endregion
    }
}
