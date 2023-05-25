using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class CaseSubKindService : GeneralService<CaseSubKind>, ICaseSubKindService
    {
        public CaseSubKindService(ApplicationDbContext db) : base(db)
        {
        }

        public CaseSubKind? Find_Incloude_CaseKind(int id)
        {
            return _db.CaseSubKinds.Where(x => x.Id == id).Include(x => x.CaseKind).FirstOrDefault();
        }

        public IEnumerable<CaseSubKind> GetAll_Incloude_CaseKind(int page)
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<CaseSubKind, CaseKind?> model = _db.CaseSubKinds.OrderByDescending(x => x).Include(x => x.CaseKind);
            if (page == 0)
            {
                return model.Take(PageRows);
            }
            return model.Skip(PageRows * page).Take(PageRows);
        }
    }
}
