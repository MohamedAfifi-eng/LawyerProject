using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawyerProject.Models.DB
{
    public class TawkeelClients
    {
        public int Id { get; set; }
        [Display(Name ="الموكل")]
        public int ClientId_FK { get; set; }
        [Display(Name = "توكيل")]
        public int TawkeelId_FK { get; set; }


        #region Relation
        [ForeignKey(nameof(ClientId_FK))]
        public Client? Client { get; set; }
        [ForeignKey(nameof(TawkeelId_FK))]
        public Tawkeel? Tawkeel { get; set; }
        #endregion
    }
}
