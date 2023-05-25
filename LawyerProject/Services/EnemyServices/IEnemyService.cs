
using LawyerProject.Models.VM;

namespace LawyerProject.Services
{
    public interface IEnemyService : IGeneralService<Enemy>
    {
        public IEnumerable<Enemy> EnemiesNotAssginedToCase(int caseId);
        public IEnumerable<Enemy> Search(SearchOnEnimyEnum option, string searchfor);
        public Enemy? FindWithCases(int id);

    }
}

