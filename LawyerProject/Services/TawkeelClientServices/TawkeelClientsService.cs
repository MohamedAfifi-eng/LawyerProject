using LawyerProject.Data;

namespace LawyerProject.Services
{
    public class TawkeelClientsService : GeneralService<TawkeelClients>, ITawkeelClientsService
    {
        public TawkeelClientsService(ApplicationDbContext db) : base(db)
        {
        }
        public TawkeelClients createNewTawkeelClient(TawkeelClients entity)
        {
            var model= _db.TawkeelClients.FirstOrDefault(x => x.TawkeelId_FK == entity.TawkeelId_FK && x.ClientId_FK == entity.ClientId_FK);
            if (model == null)
            {
                Add(entity);
                return entity;
            }
            else
            {
                return model;
            }
        }
    }
}
