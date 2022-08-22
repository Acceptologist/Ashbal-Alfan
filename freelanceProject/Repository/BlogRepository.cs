using freelanceProject.Model;

namespace freelanceProject.Repository
{
    public class BlogRepository : IRepository<Blog>
    {
        EntityContext context;
        public BlogRepository(EntityContext entityContext)
        {
            this.context=entityContext;
        }

        public int Count()
        {
            return this.context.Blogs.Count();
        }

        public void Delete(Guid id)
        {
            Blog blog = GetById(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
        }

        public List<Blog> GetAll()
        {
            return context.Blogs.ToList();
        }

        public Blog GetById(Guid id)
        {
            return context.Blogs.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Blog blog)
        {
            context.Add(blog);
            context.SaveChanges();
        }

        public void Update(Guid id, Blog oldBlog)
        {
            Blog newBlog = GetById(id);
            newBlog.Title = oldBlog.Title;
            newBlog.Content= oldBlog.Content;
            newBlog.Image=  oldBlog.Image;
            newBlog.CreationDate=oldBlog.CreationDate;

            context.SaveChanges();
        }
        public List<Blog> GetAllPagination(int page, int pageSize)
        {
            int skip = page*pageSize;
            return this.context.Blogs.Skip(skip).Take(pageSize).ToList();
        }
    }
}
