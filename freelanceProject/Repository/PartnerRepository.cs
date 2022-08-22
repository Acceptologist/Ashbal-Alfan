using freelanceProject.Model;

namespace freelanceProject.Repository
{
    public class PartnerRepository : IRepository<Partner>
    {
        EntityContext context;
        public PartnerRepository(EntityContext context)
        {
            this.context=context;
        }
        public void Delete(Guid id)
        {
            Partner partner = GetById(id);
            context.Partners.Remove(partner);
            context.SaveChanges();
        }

        public List<Partner> GetAll()
        {
            return context.Partners.ToList();
        }

        public Partner GetById(Guid id)
        {
            return context.Partners.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Partner partner)
        {
            context.Add(partner);
            context.SaveChanges();
        }

        public void Update(Guid id, Partner partner)
        {
            Partner newPartner = GetById(id);
            newPartner.Image = partner.Image;

            context.SaveChanges();
        }
        public int Count()
        {
            return this.context.Partners.Count();
        }

        public List<Partner> GetAllPagination(int page, int pageSize)
        {
            int skip = page*pageSize;
            return this.context.Partners.Skip(skip).Take(pageSize).ToList();
        }
    }
}
