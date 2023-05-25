using LawyerProject.Services;
using LawyerProject.Services.AdministrativeWorkService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LawyerProject.Controllers
{
    public class AdministrativeWorkController : GeneralController<AdministrativeWork>
    {
        private readonly ICaseService _caseService;
        private readonly IAdministrativeWorkKindService _administrativeWorkKindService;
        private readonly IAdministrativeWorkServices _administrativeWorkServices;
        public AdministrativeWorkController(IAdministrativeWorkServices service,
                                            ICaseService caseService,
                                            IAdministrativeWorkKindService administrativeWorkKindService) : base(service)
        {
            _administrativeWorkServices = service;
            _caseService = caseService;
            _administrativeWorkKindService = administrativeWorkKindService;
        }

        protected override int GetEntityId(AdministrativeWork entity)
        {
            return entity.Id;
        }
        public override void PrepViewBags()
        {
            ViewBag.CaseID_FK = new SelectList(_caseService.GetAll(), "Id", "Name");
            ViewBag.AdministrativeWorkKindID_FK = new SelectList(_administrativeWorkKindService.GetAll(), "Id", "Name");
        }
        public override AdministrativeWork? Find(int id)
        {
            return _administrativeWorkServices.Find_WithCaseAndKind(id);
        }
        public override IEnumerable<AdministrativeWork> GetAll(int page)
        {
            return _administrativeWorkServices.GetAll_WithCaseAndKind(page);
        }
        public override void UpdateFunc(AdministrativeWork entity)
        {
            entity.UpdateTime = DateTime.Now;
            _administrativeWorkServices.Update(entity);
        }
        [HttpPost]
        public override  IActionResult Create(AdministrativeWork entity,string? referer)
        {
            if (entity.CaseID_FK == 0)
            {
                entity.CaseID_FK = null;
            }
            entity.CreateTime= DateTime.Now;
            entity.UpdateTime= DateTime.Now;
            return base.Create(entity, referer);
        }
        public IActionResult Tasks()
        {
            var models= _administrativeWorkServices.GetTasks_WithCaseAndKind(0);
            return View(nameof(Index), models);
        }
    }
}
