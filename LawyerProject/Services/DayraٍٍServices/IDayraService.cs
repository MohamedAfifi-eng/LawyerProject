namespace LawyerProject.Services
{
    public interface IDayraService : IGeneralService<Dayra>
    {
        public Dayra? Find_With_Nyaba(int id);
        public IEnumerable<Dayra> GetAll_With_Nyaba(int page);
        public IEnumerable<Dayra> GetAll_With_Nyaba();
    }
}
