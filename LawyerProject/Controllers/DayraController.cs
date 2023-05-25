using Microsoft.AspNetCore.Mvc.Rendering;

namespace LawyerProject.Controllers
{
    public class DayraController : GeneralController<Dayra>
    {
        private readonly IDayraService _dayraService;
        private readonly INyabaService _nyabaService;
        public DayraController(IDayraService service,
                               INyabaService nyabaService) : base(service)
        {
            _dayraService = service;
            _nyabaService = nyabaService;
        }
        public override Dayra? Find(int id)
        {
            return _dayraService.Find_With_Nyaba(id);
        }
        public override IEnumerable<Dayra> GetAll(int page)
        {
            return _dayraService.GetAll_With_Nyaba(page);
        }
        public override void PrepViewBags()
        {
            ViewBag.NyabaId_FK = new SelectList(_nyabaService.GetAll(), "Id", "Name");
        }
        protected override int GetEntityId(Dayra entity)
        {
            return entity.ID;
        }
    }
}
