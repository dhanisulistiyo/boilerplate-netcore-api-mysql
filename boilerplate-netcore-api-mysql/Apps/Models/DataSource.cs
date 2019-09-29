using Microsoft.EntityFrameworkCore;

namespace boilerplate_netcore_api_mysql.Apps.Models
{
    /// <summary>
    /// DataSource
    /// </summary>
    public class DataSource : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public DataSource(DbContextOptions<DataSource> options) : base(options: options)
        {
        }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(x =>
            {
                x.HasKey(bc => new { bc.Id });
            });
            DataSeeding(modelBuilder);
        }

        private static void DataSeeding(ModelBuilder modelBuilder)
        {
        }

        /// <summary>
        /// Person
        /// </summary>
        public DbSet<Person> Person { get; set; }
    }
}
