
namespace LawyerProject.Controllers
{
    public class EnemyController : GeneralController<Enemy>
    {
        private readonly IEnemyService _enemyService;
        public EnemyController(IEnemyService service) : base(service)
        {
            _enemyService = service;
        }

        protected override int GetEntityId(Enemy entity)
        {
            return entity.Id;
        }
        public override Enemy? FindForDetails(int id)
        {
            return _enemyService.FindWithCases(id);
        }
        public string Search(int SearchOption,string Searchfor)
        {
            var searchResult= _enemyService.Search((Models.VM.SearchOnEnimyEnum)SearchOption, Searchfor);
            return Serialize(searchResult);
        }
    }
}

