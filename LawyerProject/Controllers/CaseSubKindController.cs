using Microsoft.AspNetCore.Mvc.Rendering;

namespace LawyerProject.Controllers
{
    public class CaseSubKindController : GeneralController<CaseSubKind>
    {
        private readonly ICaseKindService _caseKindService;
        private readonly ICaseSubKindService _caseSubKindService;
        public CaseSubKindController(ICaseSubKindService service,
                                     ICaseKindService caseKindService) : base(service)
        {
            _caseSubKindService = service;
            _caseKindService = caseKindService;
        }

        protected override int GetEntityId(CaseSubKind entity)
        {
            return entity.Id;
        }
        public override void PrepViewBags()
        {
            ViewBag.CaseKindId_FK = new SelectList(_caseKindService.GetAll(), "Id", "Name");
        }
        public override CaseSubKind? Find(int id)
        {
            return _caseSubKindService.Find_Incloude_CaseKind(id);
        }
        public override IEnumerable<CaseSubKind> GetAll(int page)
        {
            return _caseSubKindService.GetAll_Incloude_CaseKind(page);
        }
    }
}
