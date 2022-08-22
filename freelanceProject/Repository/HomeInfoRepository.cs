using freelanceProject.Model;

namespace freelanceProject.Repository
{
    public class HomeInfoRepository : IHomeInfoRepository
    {
        EntityContext context;

        public HomeInfoRepository(EntityContext context)
        {
            this.context=context;
            if (this.context.HomeInfo.Count()==0) { 
            HomeInfo homeInfo=new HomeInfo();
            this.context.HomeInfo.Add(homeInfo);
            context.SaveChanges();
            }

        }
        public HomeInfo GetData()
        {
            return this.context.HomeInfo.FirstOrDefault();
        }

        public void UpdateData(HomeInfo homeInfo)
        {
            HomeInfo newHomeInfo = GetData();
            newHomeInfo.Id=homeInfo.Id;
            newHomeInfo.ClientHosting=homeInfo.ClientHosting;
            newHomeInfo.Design=homeInfo.Design;
            newHomeInfo.WorkHours=homeInfo.WorkHours;
            newHomeInfo.Email=homeInfo.Email;
            newHomeInfo.Clients=homeInfo.Clients;
            newHomeInfo.Experience=homeInfo.Experience;
            newHomeInfo.Phone=homeInfo.Phone;
            newHomeInfo.Headquarters=homeInfo.Headquarters;
            newHomeInfo.Location=homeInfo.Location;

            context.SaveChanges();
        }
    }
}
