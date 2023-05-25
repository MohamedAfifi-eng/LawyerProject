namespace LawyerProject.Services
{
    public interface ICourtKindService : IGeneralService<CourtKind>
    {
        public CourtKind? FindIncludeCourts(int id);
    }
}
