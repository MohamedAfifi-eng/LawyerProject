using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LawyerProject.Models.DB
{
    public class CaseKind
    {
        [Display(Name = "معرف نوع القضية")]
        public int Id { get; set; }
        [Display(Name = "نوع القضية")]
        public string Name { get; set; }

        #region Relations
        public IEnumerable<CaseSubKind>? CaseSubKinds { get; set; }
        #endregion
    }
}
