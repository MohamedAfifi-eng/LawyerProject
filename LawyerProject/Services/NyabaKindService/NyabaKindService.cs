using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class NyabaKindService : GeneralService<NyabaKind>, INyabaKindService
    {
        public NyabaKindService(ApplicationDbContext db) : base(db)
        {

        }

        public NyabaKind? FindIncloudeNyabas(int id)
        {
          return  _db.NyabaKinds
                .Include(x=>x.Nyabas)
                .ThenInclude(x=>x.Court)
                .FirstOrDefault(x=>x.Id==id);    
        }
    }
}
