using freelanceProject.Model;
using freelanceProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace freelanceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IRepository<User> userRepository;

        public UserController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

      //  [Authorize]

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            List<User> users = this.userRepository.GetAll();

            return Ok(users);
        }
     //   [Authorize]

        [HttpGet("page")]
        public IActionResult GetUsersPagination(int page, int pageSize = 6)
        {
            List<User> users = this.userRepository.GetAllPagination(page, pageSize);

            return Ok(users);

        }
    }
}
