
using LawyerProject.Models.VM;

namespace LawyerProject.Services
{
    public interface IClientService : IGeneralService<Client>
    {
        IEnumerable<Client> Search(SearchOnClientEnum option,string searchfor);
        Client? FindWithCases(int clientId);
        public IEnumerable<Client> GetClientsNotAssignedtoCase(int caseId);
        public IEnumerable<Client> GetClientsNotAssignedtoTawkeel(int tawkeelId);

    }
}

