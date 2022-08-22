using freelanceProject.DTO;
using freelanceProject.Model;
using freelanceProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace freelanceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeInfoController : ControllerBase
    {
        private IHomeInfoRepository homeInfoRepository;

        private IRepository<Blog> blogRepository;
        private IRepository<User> userRepository;

        private IProductRepository productRepository;


        public HomeInfoController(IHomeInfoRepository homeInfoRepository, IRepository<Blog> blogRepository,
            IProductRepository productRepository, IRepository<User> userRepository)
        {
            this.homeInfoRepository = homeInfoRepository;
            this.blogRepository = blogRepository;
            this.productRepository=productRepository;
            this.userRepository=userRepository;
        }

        [HttpGet]
        public IActionResult GetData()
        {
            HomeInfo homeInfo = this.homeInfoRepository.GetData();

            return Ok(homeInfo);
        }
        [HttpPut]
        public IActionResult UpdateData(HomeInfo homeInfo)
        {
            if (ModelState.IsValid)
            {
                this.homeInfoRepository.UpdateData(homeInfo);


                return StatusCode(StatusCodes.Status204NoContent, "Data saved");

            }
            return BadRequest(ModelState);
        }
        // [Authorize]
        [HttpGet("admin")]

        public IActionResult GetAdminHomeInfo()
        {
            AdminHomeInfoDto adminHomeInfoDto =new AdminHomeInfoDto();
            adminHomeInfoDto.BlogsNumber=this.blogRepository.Count();
            adminHomeInfoDto.ProductsNumber=this.productRepository.Count();
            adminHomeInfoDto.UsersNumber=this.userRepository.Count();

            return Ok(adminHomeInfoDto);
        }
    }
}
