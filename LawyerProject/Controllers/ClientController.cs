
using LawyerProject.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace LawyerProject.Controllers
{
    public class ClientController : GeneralController<Client>
    {
        private readonly IClientService _clientService;
        private readonly ICaseService _caseService;
        private readonly ITawkeelService _tawkeelService;
        public ClientController(IClientService service, ICaseService caseService, ITawkeelService tawkeelService) : base(service)
        {
            _clientService = service;
            _caseService = caseService;
            _tawkeelService = tawkeelService;
        }

        protected override int GetEntityId(Client entity)
        {
            return entity.Id;
        }

        public override IActionResult Details(int id)
        {
            ViewBag.Cases= _caseService.GetCasesForClient(id);
            ViewBag.Tawkeel= _tawkeelService.GetAll_with_MaktabTawseek_forClient(id);
            return base.Details(id);
        }
        public string Search(int SearchOption,string Searchfor)
        {
            var result = _clientService.Search((SearchOnClientEnum)SearchOption, Searchfor);
            return Serialize(result);
        }
        
    }
}

