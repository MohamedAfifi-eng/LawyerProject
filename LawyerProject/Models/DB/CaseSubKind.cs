using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace LawyerProject.Models.DB
{
    public class CaseSubKind
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Display(Name = "نوع الدعوى")]
        public string Name { get; set; }
        [Display(Name = "نوع القضية")]
        public int CaseKindId_FK { get; set; }

        #region Relations
        [ForeignKey(nameof(CaseKindId_FK))]
        public CaseKind? CaseKind { get; set; }
        public IEnumerable<Case>? Cases { get; set; }
        #endregion
    }
}
