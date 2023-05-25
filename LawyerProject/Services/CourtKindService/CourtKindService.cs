using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class CourtKindService : GeneralService<CourtKind>, ICourtKindService
    {
        public CourtKindService(ApplicationDbContext db) : base(db)
        {


        }

        public CourtKind? FindIncludeCourts(int id)
        {
            return GetAll()
                .Include(x => x.Courts)
                .ThenInclude(x=>x.City)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
