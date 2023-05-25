using Microsoft.AspNetCore.Mvc;

namespace LawyerProject.Controllers
{
    public class TawkeelClientsController : GeneralController<TawkeelClients>
    {
        private readonly ITawkeelClientsService _tawkeelClientsService;
        public TawkeelClientsController(ITawkeelClientsService service) : base(service)
        {
            _tawkeelClientsService=service;
        }

        protected override int GetEntityId(TawkeelClients entity)
        {
           return entity.Id;
        }
        public override void CreateFunc(TawkeelClients entity)
        {
            _tawkeelClientsService.createNewTawkeelClient(entity);
        }
    }
}
