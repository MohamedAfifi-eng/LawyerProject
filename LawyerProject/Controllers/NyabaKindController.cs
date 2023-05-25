namespace LawyerProject.Controllers
{
    public class NyabaKindController : GeneralController<NyabaKind>
    {
        private readonly INyabaKindService _nyabaKindService;
        public NyabaKindController(INyabaKindService service) : base(service)
        {
            _nyabaKindService = service;
        }
        public override NyabaKind? Find(int id)
        {
            return _nyabaKindService.FindIncloudeNyabas(id);
        }
        protected override int GetEntityId(NyabaKind entity)
        {
            return entity.Id;
        }
    }
}
