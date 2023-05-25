using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class MaktabTawseekService : GeneralService<MaktabTawseek>, IMaktabTawseekService
    {
        public MaktabTawseekService(ApplicationDbContext db) : base(db)
        {

        }
        public MaktabTawseek? FindWithTawkeels(int id)
        {
            return GetAll().AsQueryable().Include(x => x.Tawkeels).FirstOrDefault(x => x.Id == id);
        }
    }
}
