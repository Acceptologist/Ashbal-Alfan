using freelanceProject.Model;
using freelanceProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace freelanceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IRepository<Category> categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            List<Category> categories = this.categoryRepository.GetAll();

            return Ok(categories);
        }

        [HttpGet("{id:Guid}", Name = "FindCategoryById")]
        public IActionResult FindCategoryById(Guid id)
        {
            Category category = this.categoryRepository.GetById(id);

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                this.categoryRepository.Insert(category);

                // string url = Url.Link("FindCategoryById", new { id = Category.Id });
                return Created("", category);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Category(Guid id, Category category)
        {
            if (ModelState.IsValid)
            {
                this.categoryRepository.Update(id, category);


                return StatusCode(StatusCodes.Status204NoContent, "Data saved");

            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult RemoveCategory(Guid id)
        {
            this.categoryRepository.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent, "Data saved");

        }
    }
}
