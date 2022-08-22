using freelanceProject.Model;
using freelanceProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace freelanceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private IRepository<Partner> partnerRepository;

        public PartnersController(IRepository<Partner> partnerRepository)
        {
            this.partnerRepository = partnerRepository;
        }
        [HttpGet]
        public IActionResult GetPartner()
        {
            List<Partner> Partners = this.partnerRepository.GetAll();

            return Ok(Partners);
        }

        [HttpGet("{id:Guid}", Name = "FindPartnerById")]
        public IActionResult FindPartnerById(Guid id)
        {
            Partner Partner = this.partnerRepository.GetById(id);

            return Ok(Partner);
        }

        [HttpPost]
        public IActionResult Add(Partner Partner)
        {
            if (ModelState.IsValid)
            {
                this.partnerRepository.Insert(Partner);

                // string url = Url.Link("FindPartnerById", new { id = Partner.Id });
                return Created("", Partner);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Partner(Guid id, Partner Partner)
        {
            if (ModelState.IsValid)
            {
                this.partnerRepository.Update(id, Partner);


                return StatusCode(StatusCodes.Status204NoContent, "Data saved");

            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult RemovePartner(Guid id)
        {
            this.partnerRepository.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent, "Data saved");

        }

    }
}
