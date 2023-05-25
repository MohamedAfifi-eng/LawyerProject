using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace LawyerProject.Models.DB
{
    public class Dayra
    {
        [Display(Name = "المعرف")]
        public int ID { get; set; }
        [Display(Name = "إسم و رقم الدائرة")]
        public string Name { get; set; }
        [Display(Name = "وصف")]
        public string? Description { get; set; }
        [Display(Name = "نيابة")]
        public int NyabaId_FK { get; set; }
        [Display(Name = "مكان السكرتير")]
        public string? AddressOfSecertary { get; set; }
        [Display(Name = "إسم السكرتير و رقم تليفونه")]
        public string? NameOfSecertary { get; set; }
        [Display(Name = "مكان إنعقاد الدائرة")]
        public string? AddressOfJudgment { get; set; }
        [Display(Name = "مكان الجدول")]
        public string? AddressOfGadwal { get; set; }

        #region Relation
        [ForeignKey(nameof(NyabaId_FK))]
        public Nyaba? Nyaba { get; set; }
        #endregion
    }
}
