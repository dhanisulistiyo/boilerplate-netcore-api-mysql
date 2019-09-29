using AutoMapper;
using boilerplate_netcore_api_mysql.Apps.Interfaces;
using boilerplate_netcore_api_mysql.Apps.Models;
using System.Threading.Tasks;

namespace boilerplate_netcore_api_mysql.Apps.Repository
{
    /// <summary>
    /// RepositoryBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// set db
        /// </summary>
        protected DataSource _db { get; set; }

        /// <summary>
        /// set mapper
        /// </summary>
        protected IMapper _mapper { get; set; }

        /// <summary>
        /// RepositoryBase
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public RepositoryBase(DataSource db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        /// <summary>
        /// Create record of entity
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity) => this._db.Set<T>().Add(entity);

        /// <summary>
        /// Update record of entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity) => this._db.Set<T>().Update(entity);

        /// <summary>
        /// Remove record of entity
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity) => this._db.Set<T>().Remove(entity);

        /// <summary>
        /// Bulk create array of record entity
        /// </summary>
        /// <param name="entity"></param>
        public void Creates(T[] entity) => this._db.Set<T>().AddRange(entity);

        /// <summary>
        /// Bulk update array of record entity
        /// </summary>
        /// <param name="entity"></param>
        public void Updates(T[] entity) => this._db.Set<T>().UpdateRange(entity);

        /// <summary>
        /// Bulk remove array of record entity
        /// </summary>
        /// <param name="entity"></param>
        public void Removes(T[] entity) => this._db.Set<T>().RemoveRange(entity);

        /// <summary>
        /// Save async
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync() => await this._db.SaveChangesAsync();
    }

    /// <summary>
    /// RepositoryWrapper
    /// </summary>
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DataSource _db;
        private IMapper _mapper;
        private IPersonRepository _Person;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repoContext"></param>
        /// <param name="mapperContext"></param>
        public RepositoryWrapper(DataSource repoContext, IMapper mapperContext)
        {
            _db = repoContext;
            _mapper = mapperContext;
        }

        /// <summary>
        /// Example Dependency Injection Person Repository
        /// </summary>
        public IPersonRepository Person
        {
            get
            {
                if (_Person == null) _Person = new PersonRepository(_db, _mapper);
                return _Person;
            }
        }

    }
}