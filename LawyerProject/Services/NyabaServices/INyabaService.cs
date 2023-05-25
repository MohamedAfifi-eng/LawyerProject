namespace LawyerProject.Services
{
    public interface INyabaService : IGeneralService<Nyaba>
    {
        public IEnumerable<Nyaba> GetAll_Incloude_NyabaKind_Court(int page);
        public Nyaba? Find_Incloude_NyabaKind_Court(int id);
    }
}
