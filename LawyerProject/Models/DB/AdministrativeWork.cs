using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawyerProject.Models.DB
{
    public class AdministrativeWork
    {
        [Display(Name ="المعرف")]
        public int Id { get; set; }
        [Display(Name ="المطلوب و وصفه")]
        public string? Description { get; set; }
        [Display(Name = "منشئ العمل الإداري")]
        public string? CreatedBy { get; set; }
        [Display(Name = "وقت إنشاء العمل الإداري")]
        public DateTime? CreateTime { get; set; }
        [Display(Name = "وقت اخر تعديل العمل الإداري")]
        public DateTime? UpdateTime { get; set; }
        [Display(Name = "مطلوب تنفيذه قبل")]
        public DateTime? FinishBefor { get; set; }
        [Display(Name = "تم التنفيذ")]
        public bool IsFinished { get; set; }=false;
        [Display(Name = "عمل إداري في القضية ")]
        public int? CaseID_FK { get; set; }
        [Display(Name = "نوع العمل الإداري")]
        public int? AdministrativeWorkKindID_FK { get; set; }

        #region Relations
        [Display(Name = "نوع العمل الإداري")]
        [ForeignKey(nameof(AdministrativeWorkKindID_FK))]
        public AdministrativeWorkKind? AdministrativeWorkKind { get; set; }
        [Display(Name = "القضية رقم")]
        [ForeignKey(nameof(CaseID_FK))]
        public Case? Case { get; set; }
        #endregion
    }
}
