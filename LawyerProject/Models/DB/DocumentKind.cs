using System.ComponentModel.DataAnnotations;

namespace LawyerProject.Models.DB
{
    public class DocumentKind
    {
        [Display(Name = "معرف نوع المستند")]
        public int Id { get; set; }
        [Display(Name = "إسم نوع المستند")]
        public string Name { get; set; }
    }
}
