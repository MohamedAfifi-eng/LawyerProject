namespace LawyerProject.Controllers
{
    public class CourtKindController : GeneralController<CourtKind>
    {
        private readonly ICourtKindService _courtKindService;
        public CourtKindController(ICourtKindService service) : base(service)
        {
            _courtKindService = service;
        }

        protected override int GetEntityId(CourtKind entity)
        {
            return entity.Id;
        }
        public override CourtKind? Find(int id)
        {
            return _courtKindService.FindIncludeCourts(id);
        }
    }
}
