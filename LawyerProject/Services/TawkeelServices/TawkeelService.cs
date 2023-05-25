using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class TawkeelService : GeneralService<Tawkeel>, ITawkeelService
    {
        public TawkeelService(ApplicationDbContext db) : base(db)
        {
        }

        public Tawkeel? Find_with_MaktabTawseek(int id)
        {
            return GetAll().Where(x => x.Id == id).AsQueryable().Include(x => x.MaktabTawseek).Include(x => x.TawkeelClients).ThenInclude(x => x.Client).FirstOrDefault();
        }

        public IEnumerable<Tawkeel> GetAll_with_MaktabTawseek(int? page)
        {
            if (page == null)
                return GetAll().AsQueryable().Include(x => x.MaktabTawseek);
            return GetAll((int)page).AsQueryable().Include(x => x.MaktabTawseek);
        }

        public IEnumerable<Tawkeel> GetAll_with_MaktabTawseek_forClient(int clientId)
        {
         return   _db.Tawkeels.Where(x => x.TawkeelClients.Any(y => y.ClientId_FK == clientId)).Include(x => x.MaktabTawseek);
        }
    }
}
