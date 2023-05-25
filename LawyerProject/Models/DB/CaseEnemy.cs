using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawyerProject.Models.DB
{
    public class CaseEnemy
    {
        public int Id { get; set; }
        [Display(Name ="قضية")]
        public int CaseId_FK { get; set; }
        [Display(Name = "خصم")]
        public int EnemyId_FK { get; set; }

        #region Relation
        [ForeignKey(nameof(CaseId_FK))]
        public Case? Case { get; set; }
        [ForeignKey(nameof(EnemyId_FK))]
        public Enemy? Enemy { get; set; }
        #endregion
    }
}
