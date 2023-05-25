using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class CaseKindService : GeneralService<CaseKind>, ICaseKindService
    {
        public CaseKindService(ApplicationDbContext db) : base(db)
        {


        }
        public CaseKind? FindWithSubKinds(int id)
        {
            return GetAll().Include(x => x.CaseSubKinds).FirstOrDefault(x => x.Id == id);
        }
    }
}
