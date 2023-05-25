
using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class CaseService : GeneralService<Case>, ICaseService
    {
        public CaseService(ApplicationDbContext db) : base(db)
        {
        }

        public Case? Find_incloude_Dayra_CaseSubKind_Nyaba_Court_AdminstrativeWorks(int id)
        {
            return _db.Cases.Where(x => x.Id == id)
               .Include(x => x.CaseEnemies)
               .ThenInclude(x => x.Enemy)
               .Include(x => x.CaseClients)
               .ThenInclude(x => x.Client)
                .Include(x => x.CaseSubKind)
                .Include(x => x.AdministrativeWorks)
                .ThenInclude(x => x.AdministrativeWorkKind)
                .Include(x => x.Dayra)
                .ThenInclude(x => x.Nyaba)
                .ThenInclude(x => x.Court)
                .FirstOrDefault();
        }

        public IEnumerable<Case> GetAll_incloude_Dayra_CaseSubKind_Nyaba_Court(int page)
        {
            return GetAll().AsQueryable()
                              .Include(x => x.CaseSubKind)
                              .Include(x => x.Dayra)
                              .ThenInclude(x => x.Nyaba)
                              .ThenInclude(x => x.Court);
        }

        public IEnumerable<Case> GetCasesNotAssginedToEnemy(int enemyId)
        {
            IQueryable<Case?> casesAssginedToEnemy = _db.CaseEnemies.Where(x => x.EnemyId_FK == enemyId).Select(x => x.Case);
            return _db.Cases.Except(casesAssginedToEnemy).OrderByDescending(x => x);
        }
        public IEnumerable<Case> GetCasesForClient(int clientId)
        {
            //var caseClients = _db.CaseClients.Where(y => y.ClientId_FK == clientId).Select(x=>x.Case);
            //return _db.Cases.Intersect(caseClients) .Include(x => x.Dayra).Include(x => x.CaseSubKind);
            var caseQuery = _db.Cases
                                .Where(c => c.CaseClients.Any(cc => cc.ClientId_FK == clientId))
                                .Include(c => c.Dayra)
                                .Include(c => c.CaseSubKind);
            return caseQuery;
        }

    }
}

