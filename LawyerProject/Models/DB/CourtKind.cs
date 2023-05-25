using System.ComponentModel.DataAnnotations;

namespace LawyerProject.Models.DB
{
    public class CourtKind
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Display(Name = "نوع المحكمة")]
        public string Name { get; set; }

        #region Relations

        public IEnumerable<Court>? Courts { get; set; }

        #endregion
    }
}
