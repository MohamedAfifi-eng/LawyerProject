using System.ComponentModel.DataAnnotations;

namespace LawyerProject.Models.DB
{
    public class Client
    {
        [Display(Name="المعرف")]
        public int Id { get; set; }
        [Display(Name = "إسم الموكل")]
        public string Name { get; set; }
        [Display(Name = "معلومات إضافية")]
        public string? Description { get; set; }
        [Display(Name = "موبايل")]
        public string? Phone { get; set; }
        [Display(Name = "عنوان")]
        public string? Address { get; set; }
        [Display(Name = "رقم قومي او باسبور")]
        public string? NationalNo { get; set; }

        #region Relation
        public IEnumerable<TawkeelClients>? TawkeelClients { get; set; }
        public IEnumerable<CaseClient>? CaseClients { get; set; }
        #endregion
    }
}
