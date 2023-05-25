using System.ComponentModel.DataAnnotations;

namespace LawyerProject.Models.DB
{
    public class AdministrativeWorkKind
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Display(Name = "إسم العمل الإداري")]
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
        #region Relations
        public IEnumerable<AdministrativeWork>? AdministrativeWorks { get; set; }
        #endregion
    }
}
