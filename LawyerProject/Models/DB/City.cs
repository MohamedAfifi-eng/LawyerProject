using System.ComponentModel.DataAnnotations;

namespace LawyerProject.Models.DB
{
    public class City
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Display(Name = "اسم المحافظة")]
        public string Name { get; set; }

        #region Relations
        public IEnumerable<Court>? Courts { get; set; }
        #endregion
    }
}
