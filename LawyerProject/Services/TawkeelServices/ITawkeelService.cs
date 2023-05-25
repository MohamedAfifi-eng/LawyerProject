namespace LawyerProject.Services
{
    public interface ITawkeelService : IGeneralService<Tawkeel>
    {
        public Tawkeel? Find_with_MaktabTawseek(int id);
        public IEnumerable<Tawkeel> GetAll_with_MaktabTawseek(int? page);
        public IEnumerable<Tawkeel> GetAll_with_MaktabTawseek_forClient(int clientId);
    }
}
