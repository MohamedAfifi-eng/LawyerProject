namespace LawyerProject.Controllers
{
    public class CaseKindController : GeneralController<CaseKind>
    {
        private readonly ICaseKindService _caseKindService;

        public CaseKindController(ICaseKindService service) : base(service)
        {
            _caseKindService = service;
        }
        protected override int GetEntityId(CaseKind entity)
        {
            return entity.Id;
        }
        public override CaseKind? FindForDetails(int id)
        {
            return _caseKindService.FindWithSubKinds(id);
        }
    }
}
