using JobFindingAppTeamBruxemburg.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }

        public async Task BeginTransaction()
        {
            await Database.BeginTransactionAsync();
        }

        public void Commit()
        {
            Database.CommitTransaction();
        }

        public void Rollback()
        {
            Database.RollbackTransaction();
        }

        public async Task<T> Get<T>(object id) where T : class
        {
            return await Set<T>().FindAsync(id);
        }

        public void Delete(Entity entity)
        {
            Remove(entity);
        }

        public async Task Insert(Entity entity)
        {
            await AddAsync(entity);
        }
    }
}
