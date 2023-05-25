namespace LawyerProject.Services
{
    public interface ICaseKindService : IGeneralService<CaseKind>
    {
        public CaseKind? FindWithSubKinds(int id);
    }
}
