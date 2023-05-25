namespace LawyerProject.Services.CaseEnemiesServices
{
    public interface ICaseEnemiesService:IGeneralService<CaseEnemy>
    {
        public CaseEnemy CreateNewCaseEnemy(CaseEnemy entity);
    }
}
