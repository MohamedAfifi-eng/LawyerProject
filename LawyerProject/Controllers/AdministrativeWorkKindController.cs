namespace LawyerProject.Controllers
{
    public class AdministrativeWorkKindController : GeneralController<AdministrativeWorkKind>
    {
        private readonly IAdministrativeWorkKindService _administrativeWorkKindService;
        public AdministrativeWorkKindController(IAdministrativeWorkKindService service) : base(service)
        {
            _administrativeWorkKindService = service;
        }

        protected override int GetEntityId(AdministrativeWorkKind entity)
        {
            return entity.Id;
        }
    }
}
