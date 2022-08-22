using freelanceProject.DTO;
using freelanceProject.Model;
using freelanceProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace freelanceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            List<Product> products = this.productRepository.GetAll();

            return Ok(products);
        }
        [HttpGet]
        [Route("category/id/{category_id:Guid}")]
        public IActionResult GetProductsByCategoryId(Guid category_id)
        {
            List<Product> products = this.productRepository.GetProductsByCategoryId(category_id);

            return Ok(products);
        }

        [HttpGet]
        [Route("category/name/{category_name}")]
        public IActionResult GetProductsByCategoryName(string category_name)
        {
            List<Product> products = this.productRepository.GetProductsByCategoryName(category_name);

            return Ok(products);
        }

        [HttpGet("{id:Guid}", Name = "FindProductById")]
        public IActionResult FindProductById(Guid id)
        {
            Product product = this.productRepository.GetById(id);

            return Ok(product);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                this.productRepository.Insert(product);

                // string url = Url.Link("FindProductById", new { id = Product.Id });
                return Created("", product);
            }
            return BadRequest(ModelState);
        }
        [Authorize]
        [HttpPatch("{id:Guid}")]
        public IActionResult Product(Guid id, Product product)
        {
            if (ModelState.IsValid)
            {
                this.productRepository.Update(id, product);


                return StatusCode(StatusCodes.Status204NoContent, "Data saved");

            }
            return BadRequest(ModelState);
        }
        [Authorize]
        [HttpDelete("{id:Guid}")]
        public IActionResult RemoveProduct(Guid id)
        {
            this.productRepository.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent, "Data saved");

        }

        [Authorize]
        [HttpPost("Upload"), DisableRequestSizeLimit]
        public  async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();

                var file = formCollection.Files.First();

                var pathToSave = @"C:\Users\moham\OneDrive\Documents\Angular\AdminDashboard\github\New folder\AShbal_Alfan_admin-main\src\assets\images";
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var x = new {fileName};
                    return Ok(x);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("types/{id:Guid}")]
        public IActionResult getTypes(Guid id)
        {
            if (ModelState.IsValid)
            {
                List<string>types =this.productRepository.GetProductTypes(id);

                return Ok(types);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("amounts/{id:Guid}")]
        public IActionResult getAmount(Guid id)
        {
            if (ModelState.IsValid)
            {
                List<int> amounts = this.productRepository.GetProductAmounts(id);

                return Ok(amounts);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("price")]
        public IActionResult getPrice(ProductDetailsDto productDetailsDto)
        {
            if (ModelState.IsValid)
            {
                int price;
                if (productDetailsDto.Amount!=-1)
                {
                    price = this.productRepository.GetProductPriceByTypeAndAmount(productDetailsDto.Id,
                        productDetailsDto.Type, productDetailsDto.Amount);
                }
                else {
                    price = this.productRepository.GetProductPriceByType(productDetailsDto.Id, productDetailsDto.Type);
                }

                return Ok(price);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("price-plan/{id:Guid}")]
        public IActionResult getProductPricePlan(Guid id)
        {

            var productDetailsDto = this.productRepository.GetProductPricePlan(id);
            if(productDetailsDto != null)
               return    Ok(productDetailsDto);

            return BadRequest();

        }

        [HttpPost("price-plan/{id:Guid}")]
        public IActionResult getPrice(Guid id,List<ProductDetails> productDetails)
        {
            if (ModelState.IsValid)
            {
                this.productRepository.UpdateProductPricePlan(id, productDetails);
               

                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost("update2")]

        public IActionResult Upload(IFormFile file)
        {
            try
            {
                // var file = files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    fileName = dbPath;
                    return Ok(fileName);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
