using LawyerProject.Data;

namespace LawyerProject.Services.CaseEnemiesServices
{
    public class CaseEnemiesService : GeneralService<CaseEnemy>, ICaseEnemiesService
    {
        public CaseEnemiesService(ApplicationDbContext db) : base(db)
        {
        }
        public CaseEnemy CreateNewCaseEnemy(CaseEnemy entity)
        {
            CaseEnemy? model = GetAll().FirstOrDefault(x => x.EnemyId_FK == entity.EnemyId_FK && x.CaseId_FK == entity.CaseId_FK);
            if (model == null)
            {
                Add(entity);
                return entity;
            }
            return model;
        }
    }
}
