namespace LawyerProject.Services
{
    public interface INyabaKindService : IGeneralService<NyabaKind>
    {
        public NyabaKind? FindIncloudeNyabas(int id);
    }
}
