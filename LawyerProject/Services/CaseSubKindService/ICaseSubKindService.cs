namespace LawyerProject.Services
{
    public interface ICaseSubKindService : IGeneralService<CaseSubKind>
    {
        public CaseSubKind? Find_Incloude_CaseKind(int id);
        public IEnumerable<CaseSubKind> GetAll_Incloude_CaseKind(int page);
    }
}
