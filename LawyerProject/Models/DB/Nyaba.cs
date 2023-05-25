using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace LawyerProject.Models.DB
{
    public class Nyaba
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Display(Name = "إسم النيابة")]
        public string Name { get; set; }
        [Display(Name = "معلومات إضافية")]
        public string? Description { get; set; }
        [Display(Name = "نوع النيابة")]
        public int NyabaKindId_FK { get; set; }
        [Display(Name = "في محكمة")]
        public int CourtId_FK { get; set; }

        #region Relations
        [ForeignKey(nameof(CourtId_FK))]
        public Court? Court { get; set; }
        [ForeignKey(nameof(NyabaKindId_FK))]
        public NyabaKind? NyabaKind { get; set; }
        public IEnumerable<Dayra>? Dayras { get; set; }
        #endregion

    }
}
