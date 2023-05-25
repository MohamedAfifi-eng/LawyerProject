namespace LawyerProject.Services
{
    public interface IGeneralService<T>
    {
        public T Add(T entity);
        public T? Find(int id);
        public Boolean Delete(T entity);
        public Boolean Delete(int id);
        public Boolean Update(T entity);
        public IQueryable<T> GetAll();
        public IQueryable<T> GetAll(int page);


    }
}
