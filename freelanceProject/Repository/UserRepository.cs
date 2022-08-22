using freelanceProject.Model;

namespace freelanceProject.Repository
{
    public class UserRepository : IRepository<User>
    {
        EntityContext context;

        public UserRepository(EntityContext context)
        {
            this.context=context;
        }
        public int Count()
        {
            return this.context.Users.Count();
        }

        public void Delete(Guid id)
        {
            User user = GetById(id);
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return context.Users.FirstOrDefault(d => d.Id== id.ToString());
        }

        public void Insert(User user)
        {
            context.Add(user);
            context.SaveChanges();
        }

        public void Update(Guid id, User oldUser)
        {
            User newUser = GetById(id);
            oldUser.Id=newUser.Id;
            newUser =oldUser;
            context.SaveChanges();
        }
        public List<User> GetAllPagination(int page, int pageSize)
        {
            int skip = page*pageSize;
            return this.context.Users.Skip(skip).Take(pageSize).ToList();
        }
    }
}
