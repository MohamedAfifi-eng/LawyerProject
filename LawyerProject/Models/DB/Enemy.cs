using System.ComponentModel.DataAnnotations;

namespace LawyerProject.Models.DB
{
    public class Enemy
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Display(Name = "إسم الخصم")]
        public string Name { get; set; }
        [Display(Name = "رقم قومي / باسبور")]
        public string? National { get; set; }
        [Display(Name = "جنسية")]
        [StringLength(maximumLength:20)]
        public string? Nationality { get; set; }
        [Display(Name = "عنوان الإعلان")]
        public string? Address { get; set; }
        [Display(Name = "رقم تليفون")]
        public string? Phone { get; set; }
        [Display(Name = "بيانات محامي الخصم")]
        public string? EnemyLawyer { get; set; }

        #region MyRegion
        public IEnumerable<CaseEnemy>? CaseEnemye { get; set; }
        #endregion
    }
}
