using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawyerProject.Models.DB
{
    public class Case
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Display(Name = "نوع الدعوى")]
        public int CaseSubKindId_FK { get; set; }
        [Display(Name = "ما زالت قائمة")]
        public bool IsActive { get; set; } = true;
        [Display(Name = "اخر تعديل")]
        public DateTime? LastUpdatedOn { get; set; }
        [Display(Name = "سجلت بتاريخ")]
        public DateTime? CreateOn { get; set; }
        [Display(Name = "قضية رقم")]
        public string? Name { get; set; }
        [Display(Name = "دائرة")]
        public int? DayraId_FK { get; set; }

        #region Relation
        [ForeignKey(nameof(CaseSubKindId_FK))]
        public CaseSubKind? CaseSubKind { get; set; }
        [ForeignKey(nameof(DayraId_FK))]
        public Dayra? Dayra { get; set; }
        public IEnumerable<AdministrativeWork>? AdministrativeWorks { get; set; }
        public IEnumerable<CaseClient>? CaseClients { get; set; }
        public IEnumerable<CaseEnemy>? CaseEnemies { get; set; }
        #endregion
        public override string ToString()
        {
            return Name;
        }
    }
}
