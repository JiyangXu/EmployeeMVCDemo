using Microsoft.EntityFrameworkCore;


namespace Employee.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Models.Employee> Employee { get; set; }
    }
}
