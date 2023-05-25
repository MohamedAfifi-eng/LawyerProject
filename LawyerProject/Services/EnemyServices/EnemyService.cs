
using LawyerProject.Data;
using LawyerProject.Models.VM;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LawyerProject.Services
{
    public class EnemyService : GeneralService<Enemy>, IEnemyService
    {
        public EnemyService(ApplicationDbContext db) : base(db)
        {
        }

        public IEnumerable<Enemy> EnemiesNotAssginedToCase(int caseId)
        {
            var casesAssgined = _db.CaseEnemies.Where(x => x.CaseId_FK == caseId).Select(x=>x.Enemy);
            return _db.Enemies.Except(casesAssgined).OrderByDescending(x=>x);
        }

        public IEnumerable<Enemy> Search(SearchOnEnimyEnum option, string searchfor)
        {
            IEnumerable<Enemy> result;
            switch (option)
            {
                case SearchOnEnimyEnum.Id:
                    result= _db.Enemies.Where(x => x.Id == Convert.ToInt32(searchfor));
                    break;
                case SearchOnEnimyEnum.Name:
                    result= _db.Enemies.Where(x => x.Name.Contains(searchfor));
                    break;
                case SearchOnEnimyEnum.National:
                    result= _db.Enemies.Where(x => x.National.Contains(searchfor));
                    break;
                case SearchOnEnimyEnum.Nationality:
                    result = _db.Enemies.Where(x => x.Nationality.Contains(searchfor));
                    break;
                case SearchOnEnimyEnum.Address:
                    result = _db.Enemies.Where(x => x.Address.Contains(searchfor));
                    break;
                case SearchOnEnimyEnum.Phone:
                    result = _db.Enemies.Where(x => x.Phone.Contains(searchfor));
                    break;
                case SearchOnEnimyEnum.EnemyLawyer:
                    result = _db.Enemies.Where(x => x.EnemyLawyer.Contains(searchfor));
                    break;
                default:
                    result = new List<Enemy>();
                    break;
            }
            return result;
        }
        public Enemy? FindWithCases(int id)
        {
            return _db.Enemies.Include(x => x.CaseEnemye).ThenInclude(x=>x.Case).FirstOrDefault(x => x.Id == id);
        }

    }
}

