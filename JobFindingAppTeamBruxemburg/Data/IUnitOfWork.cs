using JobFindingAppTeamBruxemburg.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Data
{
    public interface IUnitOfWork
    {
        Task Save();
        Task BeginTransaction();
        void Commit();
        void Rollback();

        ITagRepository TagRepository { get; }
    }
}
