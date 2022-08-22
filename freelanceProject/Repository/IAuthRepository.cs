using freelanceProject.Model;

namespace freelanceProject.Repository
{
    public interface IAuthRepository
    {
        public AuthModel GetToken(User admin,string role);
    }
}
