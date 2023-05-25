using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawyerProject.Models.DB
{
    public class Court
    {
        [Display(Name = "المعرف")]
        public int ID { get; set; }
        [Display(Name = "اسم المحكمة")]
        public string Name { get; set; }
        [Display(Name = "عنوان التكليف")]
        public string Address { get; set; }
        [Display(Name = "معلومات إضافية")]
        public string? Discription { get; set; }
        [Display(Name = "محافظة")]
        public int CityID_FK { get; set; }
        [Display(Name = "نوع المحكمة")]
        public int CourtKindID_FK { get; set; }

        #region Relations
        [ForeignKey(nameof(CityID_FK))]
        public City? City { get; set; }
        [ForeignKey(nameof(CourtKindID_FK))]
        public CourtKind? CourtKind { get; set; }
        public IEnumerable<Nyaba>? Nyabas { get; set; }
        #endregion
        public override string ToString()
        {
            return Name;
        }
    }
}
