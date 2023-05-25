using LawyerProject.Models.DB;

namespace LawyerProject.Services.CaseClientsServices
{
    public interface ICaseClientsService:IGeneralService<CaseClient>
    {
        public CaseClient CreateNew(CaseClient entity);
    }
}
