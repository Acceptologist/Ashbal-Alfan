using freelanceProject.Model;
using freelanceProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace freelanceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IRepository<Blog> blogRepository;

        public BlogController(IRepository<Blog> blogRebository)
        {
            this.blogRepository = blogRebository;
        }

        [HttpGet]
        public IActionResult GetBlog()
        {
            List<Blog> blogs = this.blogRepository.GetAll();
            
            return Ok(blogs);
        }

        [HttpGet("page")]
        public IActionResult GetAllBlogsPagination(int page,int pageSize=6) {
            List<Blog> blogs = this.blogRepository.GetAllPagination(page, pageSize);

            return Ok(blogs);

        }

        [HttpGet("{id:Guid}", Name = "FindBlogById")]
        public IActionResult FindBlogById(Guid id)
        {
            Blog blog = this.blogRepository.GetById(id);

            return Ok(blog);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            if (ModelState.IsValid)
            {
                this.blogRepository.Insert(blog);

               // string url = Url.Link("FindBlogById", new { id = blog.Id });
                return Created("", blog);
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPatch("{id:Guid}")]
        public IActionResult Blog(Guid id,Blog blog)
        {
            if (ModelState.IsValid)
            {
                this.blogRepository.Update(id, blog);


                return StatusCode(StatusCodes.Status204NoContent, "Data saved");

            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpDelete("{id:Guid}")]
        public IActionResult RemoveBlog(Guid id)
        {
            this.blogRepository.Delete(id);
            return Ok(new {id});

        }
    }
}
