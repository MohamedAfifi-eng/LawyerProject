using LawyerProject.Data;

namespace LawyerProject.Services.CaseClientsServices
{
    public class CaseClientsService : GeneralService<CaseClient>, ICaseClientsService
    {
        public CaseClientsService(ApplicationDbContext db) : base(db)
        {
        }
        public CaseClient CreateNew(CaseClient entity)
        {
            CaseClient? model = _db.CaseClients.FirstOrDefault(x => x.CaseId_FK == entity.CaseId_FK && x.ClientId_FK == entity.ClientId_FK);
            if (model == null)
            {
                Add(entity);
                return entity;
            }
            return model;
        }


    }
}
