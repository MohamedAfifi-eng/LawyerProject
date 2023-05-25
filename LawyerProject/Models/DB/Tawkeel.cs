using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawyerProject.Models.DB
{
    public class Tawkeel
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Display(Name= "رقم التوكيل و حرفه")]
        public string Name { get; set; }
        [Display(Name = "تاريخ إنشاء التوكيل")]
        public DateTime? Date { get; set; }
        [Display(Name = "مكتب توثيق")]
        public int MaktabTawseekId_FK { get; set; }
        public string? TawkeelPath { get; set; }
        #region Relations
        [ForeignKey(nameof(MaktabTawseekId_FK))]
        public MaktabTawseek? MaktabTawseek { get; set; }
        public IEnumerable<TawkeelClients>? TawkeelClients { get; set; }
        #endregion
    }
}
