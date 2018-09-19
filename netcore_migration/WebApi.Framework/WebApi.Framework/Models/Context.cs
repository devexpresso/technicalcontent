using System.Data.Entity;

namespace WebApi.Framework.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public Context() : base("name=Context")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Account> Accounts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Project> Projects { get; set; }
    }
}