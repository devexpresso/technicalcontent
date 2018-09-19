using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Model;

namespace EmployeeManagement.Repository
{
    public class Context : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public Context() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Department> Departments { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Project> Projects { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Client> Clients { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Skills> Skills { get; set; }
    }
}
