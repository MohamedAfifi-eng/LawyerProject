
using LawyerProject.Services.AdministrativeWorkService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LawyerProject.Controllers
{
    public class CaseController : GeneralController<Case>
    {
        private readonly ICaseService _caseService;
        private readonly ICaseSubKindService _caseSubKindService;
        private readonly IDayraService _dayraService;
        private readonly IAdministrativeWorkKindService _administrativeWorkKindService;
        public CaseController(ICaseService service,
                              ICaseSubKindService caseSubKindService,
                              IDayraService dayraService,
                              IAdministrativeWorkKindService administrativeWorkKindService) : base(service)
        {
            _caseService = service;
            _caseSubKindService = caseSubKindService;
            _dayraService = dayraService;
            _administrativeWorkKindService = administrativeWorkKindService;
        }

        protected override int GetEntityId(Case entity)
        {
            return entity.Id;
        }
        public override void PrepViewBags()
        {

            ViewBag.CaseSubKindId_FK = new SelectList(_caseSubKindService.GetAll(), "Id", "Name");
            ViewBag.DayraId_FK = new SelectList(_dayraService.GetAll(), "ID", "Name");
        }
        public override Case? Find(int id)
        {
            return _caseService.Find_incloude_Dayra_CaseSubKind_Nyaba_Court_AdminstrativeWorks(id);
        }
        public override IEnumerable<Case> GetAll(int page)
        {
            return _caseService.GetAll_incloude_Dayra_CaseSubKind_Nyaba_Court(page);
        }
        [HttpPost]
        public override IActionResult Create(Case entity,string? referer)
        {
            entity.LastUpdatedOn = DateTime.Now;
            entity.CreateOn = entity.LastUpdatedOn;
            entity.IsActive = true;
            return base.Create(entity);
        }
        [HttpPost]
        public override IActionResult Edit(Case entity)
        {
            entity.LastUpdatedOn=DateTime.Now;
            return base.Edit(entity);
        }
        public override IActionResult Details(int id)
        {
            ViewBag.AdministrativeWorkKindID_FK = new SelectList(_administrativeWorkKindService.GetAll(), "Id", "Name");

            return base.Details(id);
        }


    }
}

