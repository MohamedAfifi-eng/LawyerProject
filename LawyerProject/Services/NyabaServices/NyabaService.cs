using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class NyabaService : GeneralService<Nyaba>, INyabaService
    {
        public NyabaService(ApplicationDbContext db) : base(db)
        {
        }

        public Nyaba? Find_Incloude_NyabaKind_Court(int id)
        {
            return _db.Nyabas.Where(x => x.Id == id)
                .Include(x => x.NyabaKind)
                .Include(x => x.Court)
                .Include(c=>c.Dayras)
                .FirstOrDefault();
        }

        public IEnumerable<Nyaba> GetAll_Incloude_NyabaKind_Court(int page)
        {

            return GetAll(page).AsQueryable().Include(x => x.NyabaKind).Include(x => x.Court);
        }
    }
}
