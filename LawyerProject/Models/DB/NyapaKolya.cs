namespace LawyerProject.Models.DB
{
    public class NyapaKolya
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CourtId_FK { get; set; }
        public int NyabaKindId_FK { get; set; }
        public int CityId_FK { get; set; }
        public string? NyabaPosition { get; set; }
    }
}
