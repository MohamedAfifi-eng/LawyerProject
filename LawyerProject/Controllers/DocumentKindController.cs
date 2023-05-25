
namespace LawyerProject.Controllers
{
    public class DocumentKindController : GeneralController<DocumentKind>
    {
        private readonly IGeneralService<DocumentKind> _documentkindService;
        public DocumentKindController(IGeneralService<DocumentKind> service) : base(service)
        {
            _documentkindService= service;
        }

        protected override int GetEntityId(DocumentKind entity)
        {
            return entity.Id;
        }
    }
}

