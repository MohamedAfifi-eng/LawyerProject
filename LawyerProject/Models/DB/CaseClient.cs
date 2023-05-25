using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawyerProject.Models.DB
{
    public class CaseClient
    {
        [Display(Name ="المعرف")]
        public int Id { get; set; }
        [Display(Name = "قضية")]
        public int CaseId_FK { get; set; }
        [Display(Name = "موكل")]
        public int ClientId_FK { get; set; }
        #region Relation
        [ForeignKey(nameof(CaseId_FK))]
        public Case? Case { get; set; }
        [ForeignKey(nameof(ClientId_FK))]
        public Client? Client { get; set; }
        #endregion
    }
}
