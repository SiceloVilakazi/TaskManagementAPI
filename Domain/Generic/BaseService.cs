namespace Domain.Generic
{
    /// <summary>
    /// provides capabilities of calling the unit of work to call the save method
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// initializes the constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// instantiating the unit of work
        /// </summary>
        protected internal IUnitOfWork UnitOfWork { get; set; }
    }
}

