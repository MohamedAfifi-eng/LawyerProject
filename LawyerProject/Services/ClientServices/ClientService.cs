
using LawyerProject.Data;
using LawyerProject.Models.VM;
using Microsoft.EntityFrameworkCore;

namespace LawyerProject.Services
{
    public class ClientService : GeneralService<Client>, IClientService
    {
        public ClientService(ApplicationDbContext db) : base(db)
        {
        }

        public Client? FindWithCases(int clientId)
        {
            return GetAll()
                 .Include(x => x.TawkeelClients)
                 .ThenInclude(x => x.Tawkeel)
                 .Include(x => x.CaseClients)
                 .ThenInclude(x => x.Case)
                 .FirstOrDefault(x => x.Id == clientId&& x.CaseClients.Any(y => y.ClientId_FK == clientId));
        }
        public IEnumerable<Client> GetClientsNotAssignedtoCase(int caseId)
        {
            var clientAssigned=_db.CaseClients.Where(x=>x.CaseId_FK == caseId).Select(x=>x.Client);
            return _db.Clients.Except(clientAssigned).OrderByDescending(x=>x.Id);
        }
        public IEnumerable<Client> Search(SearchOnClientEnum option, string searchfor)
        {
            switch (option)
            {
                case SearchOnClientEnum.NationalId:
                   return _db.Clients.Where(x => x.NationalNo==searchfor).ToList(); ;
                    break;
                case SearchOnClientEnum.Name:
                    return _db.Clients.Where(x => x.Name.Contains(searchfor)).ToList();
                    break;
                case SearchOnClientEnum.Id:
                    int id=0;
                    int.TryParse(searchfor,out id);
                    return _db.Clients.Where(x => x.Id== id).ToList(); ;
                    break;
                case SearchOnClientEnum.Phone:
                    return _db.Clients.Where(x => x.Phone.Contains(searchfor)).ToList(); ;
                    break;
                case SearchOnClientEnum.Address:
                    return _db.Clients.Where(x => x.Address.Contains(searchfor)).ToList(); ;
                    break;
                default:
                    return new List<Client>();
                    break;
            }
        }
        public IEnumerable<Client> GetClientsNotAssignedtoTawkeel(int tawkeelId)
        {
            return _db.Clients.Where(x => !x.TawkeelClients.Any(y => y.TawkeelId_FK == tawkeelId));
        }



    }
}

