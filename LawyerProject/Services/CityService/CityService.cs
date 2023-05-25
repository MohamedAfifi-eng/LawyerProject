using LawyerProject.Data;

namespace LawyerProject.Services
{
    public class CityService : GeneralService<City>, ICityService
    {
        public CityService(ApplicationDbContext db) : base(db)
        {
        }
    }
}
