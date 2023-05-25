using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class courtService : GeneralService<Court>, IcourtService
    {
        public courtService(ApplicationDbContext db) : base(db)
        {
        }

        public Court? Find_Incloude_City_Kind(int id)
        {
            return _db.Courts.Where(x => x.ID == id)
                                .Include(x => x.CourtKind)
                                .Include(x => x.City)
                                .FirstOrDefault();
        }



        public Court? Find_Incloude_Nyabat_City_Kind(int id)
        {
            return GetAll().AsQueryable()
                .Include(x => x.CourtKind)
                .Include(x => x.City)
                .Include(x => x.Nyabas)
                .ThenInclude(x=>x.NyabaKind)
                .FirstOrDefault(x=>x.ID==id);
        }

        public IEnumerable<Court> GetAll_Incloude_City_Kind(int page)
        {
            return GetAll(page)
                .AsQueryable()
                .Include(x => x.CourtKind)
                .Include(x => x.City);
        }
    }
}
