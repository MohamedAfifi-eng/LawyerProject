using LawyerProject.Models.DB;

namespace LawyerProject.Services.AdministrativeWorkService
{
    public interface IAdministrativeWorkServices:IGeneralService<AdministrativeWork>
    {
        public AdministrativeWork? Find_WithCaseAndKind(int id);
        public IQueryable< AdministrativeWork> GetAll_WithCaseAndKind(int page);
        public IQueryable< AdministrativeWork> GetTasks_WithCaseAndKind(int page);
    }
}
