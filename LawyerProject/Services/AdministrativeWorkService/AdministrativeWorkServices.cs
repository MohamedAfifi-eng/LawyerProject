using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services.AdministrativeWorkService
{
    public class AdministrativeWorkServices : GeneralService<AdministrativeWork>, IAdministrativeWorkServices
    {
        public AdministrativeWorkServices(ApplicationDbContext db) : base(db)
        {
        }

        public AdministrativeWork? Find_WithCaseAndKind(int id)
        {
            return GetAll().AsQueryable().Include(x => x.Case).Include(x => x.AdministrativeWorkKind).FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<AdministrativeWork> GetAll_WithCaseAndKind(int page)
        {
            return GetAll(page).AsQueryable().Include(x => x.Case).Include(x => x.AdministrativeWorkKind);
        }
        public IQueryable<AdministrativeWork> GetTasks_WithCaseAndKind(int page)
        {
            return GetAll_WithCaseAndKind(page).Where(x => x.IsFinished == false).OrderBy(x => x.FinishBefor);
        }

    }
}
