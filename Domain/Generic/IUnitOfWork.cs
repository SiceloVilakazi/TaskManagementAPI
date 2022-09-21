namespace Domain.Generic
{
    /// <summary>
    /// provides functionality to commit database changes
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits changes to the database
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
    }
}
