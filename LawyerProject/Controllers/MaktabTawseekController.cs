namespace LawyerProject.Controllers
{
    public class MaktabTawseekController : GeneralController<MaktabTawseek>
    {
        private readonly IMaktabTawseekService _maktabTawseekService;
        public MaktabTawseekController(IMaktabTawseekService service) : base(service)
        {
            _maktabTawseekService = service;
        }
        protected override int GetEntityId(MaktabTawseek entity)
        {
            return entity.Id;
        }
        public override MaktabTawseek? FindForDetails(int id)
        {
            return _maktabTawseekService.FindWithTawkeels(id);
        }
    }
}
