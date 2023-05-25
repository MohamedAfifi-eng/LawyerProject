using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LawyerProject.Models.DB
{
    public class MaktabTawseek
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }

        [Display(Name = "إسم مكتب التوثيق")]
        public string Name { get; set; }
        [Display(Name = "عنوان مكتب التوثيق")]
        public string? Address { get; set; }

        #region Relations
        public IEnumerable<Tawkeel>? Tawkeels { get; set; }
        #endregion
    }
}
