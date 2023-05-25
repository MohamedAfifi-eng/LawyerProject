using Microsoft.AspNetCore.Mvc.Rendering;

namespace LawyerProject.Controllers
{
    public class NyabaController : GeneralController<Nyaba>
    {
        private readonly INyabaService _nyabaService;
        private readonly INyabaKindService _nyabaKindService;
        private readonly IcourtService _courtService;
        public NyabaController(INyabaService service,
                               INyabaKindService nyabaKindService,
                               IcourtService courtService) : base(service)
        {
            _nyabaService = service;
            _nyabaKindService = nyabaKindService;
            _courtService = courtService;
        }
        public override Nyaba? Find(int id)
        {
            return _nyabaService.Find_Incloude_NyabaKind_Court(id);
        }
        public override IEnumerable<Nyaba> GetAll(int page)
        {
            return _nyabaService.GetAll_Incloude_NyabaKind_Court(page);
        }
        public override void PrepViewBags()
        {
            ViewBag.NyabaKindId_FK = new SelectList(_nyabaKindService.GetAll(), "Id", "Name");
            ViewBag.CourtId_FK = new SelectList(_courtService.GetAll(), "ID", "Name");
        }
        protected override int GetEntityId(Nyaba entity)
        {
            return entity.Id;
        }
    }
}
