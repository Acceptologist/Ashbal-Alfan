using freelanceProject.Model;

namespace freelanceProject.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        EntityContext context;
        public CategoryRepository(EntityContext context)
        {
            this.context=context;
        }

        public void Delete(Guid id)
        {
            Category category = GetById(id);
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(Guid id)
        {
            return context.Categories.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Category category)
        {
            context.Add(category);
            context.SaveChanges();
        }

        public void Update(Guid id, Category category)
        {
            Category newCategory = GetById(id);
            newCategory.Name = category.Name;

            context.SaveChanges();
        }
        public int Count()
        {
            return this.context.Categories.Count();
        }

        public List<Category> GetAllPagination(int page, int pageSize)
        {
            int skip = page*pageSize;
            return this.context.Categories.Skip(skip).Take(pageSize).ToList();
        }
    }
}
