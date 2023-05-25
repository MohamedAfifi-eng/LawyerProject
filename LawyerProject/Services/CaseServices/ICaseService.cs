
namespace LawyerProject.Services
{
    public interface ICaseService : IGeneralService<Case>
    {
        public Case? Find_incloude_Dayra_CaseSubKind_Nyaba_Court_AdminstrativeWorks(int id);
        public IEnumerable<Case> GetAll_incloude_Dayra_CaseSubKind_Nyaba_Court(int page);
        public IEnumerable<Case> GetCasesNotAssginedToEnemy(int enemyId);
        public IEnumerable<Case> GetCasesForClient(int clientId);
    }
}

