using LawyerProject.Data;

namespace LawyerProject.Services
{
    public class GeneralService<T> : IGeneralService<T> where T : class
    {
        protected readonly ApplicationDbContext _db;
        public GeneralService(ApplicationDbContext db)
        {
            _db = db;
        }
        protected readonly int PageRows = 20;
        private int Save()
        {
            return _db.SaveChanges();
        }
        public T Add(T entity)
        {
            _db.Set<T>().Add(entity);
            Save();
            return entity;
        }

        public bool Delete(T entity)
        {
            _db.Remove<T>(entity);
            return Save() > 0;

        }

        public bool Delete(int id)
        {
            T? entity = Find(id);
            if (entity is not null)
                return Delete(entity);
            else
                return false;
        }

        public IQueryable<T> GetAll()
        {
            IOrderedQueryable<T> model = _db.Set<T>().OrderByDescending(x => x);
            return model;
        }

        public IQueryable<T> GetAll(int page)
        {
            if (page == 0)
                return GetAll().Take(PageRows);
            return GetAll().Skip(PageRows * page - 1).Take(page);
        }

        public bool Update(T entity)
        {
            _db.Update<T>(entity);
            return Save() > 0;
        }

        public T? Find(int id)
        {
            return _db.Find<T>(id);
        }
    }
}
