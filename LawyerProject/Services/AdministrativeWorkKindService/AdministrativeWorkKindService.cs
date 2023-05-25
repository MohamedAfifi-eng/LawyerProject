using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class AdministrativeWorkKindService : GeneralService<AdministrativeWorkKind>, IAdministrativeWorkKindService
    {
        public AdministrativeWorkKindService(ApplicationDbContext db) : base(db)
        {
        }

    }
}
