namespace LawyerProject.Controllers
{
    public class CityController : GeneralController<City>
    {
        private readonly ICityService _cityService;
        public CityController(ICityService service) : base(service)
        {
            _cityService = service;
        }
        protected override int GetEntityId(City entity)
        {
            return entity.Id;
        }
    }
}
