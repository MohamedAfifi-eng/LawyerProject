namespace LawyerProject.Services
{
    public interface IMaktabTawseekService : IGeneralService<MaktabTawseek>
    {
        public MaktabTawseek? FindWithTawkeels(int id);
    }
}
