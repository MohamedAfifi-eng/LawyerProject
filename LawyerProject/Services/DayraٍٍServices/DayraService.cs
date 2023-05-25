using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class DayraService : GeneralService<Dayra>, IDayraService
    {
        public DayraService(ApplicationDbContext db) : base(db)
        {
        }

        public Dayra? Find_With_Nyaba(int id)
        {
            return _db.Dayras.Where(x => x.ID == id).Include(x => x.Nyaba).FirstOrDefault();
        }

        public IEnumerable<Dayra> GetAll_With_Nyaba(int page)
        {
            return GetAll(page).AsQueryable().Include(x => x.Nyaba);
        }

        public IEnumerable<Dayra> GetAll_With_Nyaba()
        {
            return GetAll().AsQueryable().Include(x => x.Nyaba);
        }
    }
}
