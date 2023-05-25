using LawyerProject.Services.CaseEnemiesServices;
using Microsoft.AspNetCore.Mvc;

namespace LawyerProject.Controllers
{
    public class CaseEnemyController : GeneralController<CaseEnemy>
    {
        private readonly ICaseEnemiesService _caseEnemiesService;
        public CaseEnemyController(ICaseEnemiesService service) : base(service)
        {
            _caseEnemiesService= service;
        }

        protected override int GetEntityId(CaseEnemy entity)
        {
            return entity.Id;
        }
        public override void CreateFunc(CaseEnemy entity)
        {
            _caseEnemiesService.CreateNewCaseEnemy(entity);
        }
    }
}
