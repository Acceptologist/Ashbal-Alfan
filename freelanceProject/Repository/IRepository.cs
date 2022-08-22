using freelanceProject.Model;
using System.Collections.Generic;


namespace freelanceProject.Repository
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public List<T> GetAllPagination(int page,int pageSize);

        public T GetById(Guid id);
        public void Insert(T blog);
        public void Update(Guid id, T blog);
        public void Delete(Guid id);

        public int Count();
    }
}
