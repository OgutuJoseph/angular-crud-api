using angular_crud_api.Models;
using Microsoft.EntityFrameworkCore;

namespace angular_crud_api.Data
{
    public class AngularCrudDbContext : DbContext
    {
        public AngularCrudDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
