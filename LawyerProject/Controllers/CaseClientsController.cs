using LawyerProject.Services.CaseClientsServices;
using Microsoft.AspNetCore.Mvc;

namespace LawyerProject.Controllers
{
    public class CaseClientsController : GeneralController<CaseClient>
    {
        private readonly ICaseClientsService _caseClientsService;
        public CaseClientsController(ICaseClientsService service  ) : base(service)
        {
            _caseClientsService = service;
        }

        protected override int GetEntityId(CaseClient entity)
        {
            return entity.Id;
        }
        public override void CreateFunc(CaseClient entity)
        {
            _caseClientsService.CreateNew(entity);
        }
    }
}
