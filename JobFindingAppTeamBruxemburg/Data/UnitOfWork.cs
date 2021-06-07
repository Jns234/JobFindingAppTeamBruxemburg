using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Data
{
    

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ITagRepository TagRepository { get; private set; }


        public UnitOfWork(ApplicationDbContext context,
                ITagRepository tagRepository)
        {
            _context = context;

            TagRepository = tagRepository;
        }

        public async Task BeginTransaction()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
