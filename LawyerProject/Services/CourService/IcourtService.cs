namespace LawyerProject.Services
{
    public interface IcourtService : IGeneralService<Court>
    {
        public IEnumerable<Court> GetAll_Incloude_City_Kind(int page);
        public Court? Find_Incloude_City_Kind(int id);
        public Court? Find_Incloude_Nyabat_City_Kind(int id);
    }
}
