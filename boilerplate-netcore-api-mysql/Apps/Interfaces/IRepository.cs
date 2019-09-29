using System.Threading.Tasks;

namespace boilerplate_netcore_api_mysql.Apps.Interfaces
{
    /// <summary>
    /// IRepositoryWrapper
    /// </summary>
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// set person
        /// </summary>
        IPersonRepository Person { get; }
    }

    /// <summary>
    /// IRepositoryBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Create record of entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Update record of entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Remove record of entity
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// Bulk create records of entity
        /// </summary>
        /// <param name="entity"></param>
        void Creates(T[] entity);

        /// <summary>
        /// Bulk update records of entity
        /// </summary>
        /// <param name="entity"></param>
        void Updates(T[] entity);

        /// <summary>
        /// Bulk remove record of entity
        /// </summary>
        /// <param name="entity"></param>
        void Removes(T[] entity);

        /// <summary>
        /// Asynchronous save
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}

