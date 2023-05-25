using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LawyerProject.Models.DB
{
    public class NyabaKind
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Display(Name = "إسم نوع النيابة")]
        public string Name { get; set; }

        #region Relations
        public IEnumerable<Nyaba>? Nyabas { get; set; }
        #endregion
    }
}
