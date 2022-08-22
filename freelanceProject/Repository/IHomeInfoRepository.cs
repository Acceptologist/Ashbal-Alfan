using freelanceProject.Model;

namespace freelanceProject.Repository
{
    public interface IHomeInfoRepository
    {
        public HomeInfo GetData();
        public void UpdateData(HomeInfo homeInfo);


    }
}
