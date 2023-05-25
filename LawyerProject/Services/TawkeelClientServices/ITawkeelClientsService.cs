namespace LawyerProject.Services
{
    public interface ITawkeelClientsService:IGeneralService<TawkeelClients>
    {
        public TawkeelClients createNewTawkeelClient(TawkeelClients entity);

    }
}
