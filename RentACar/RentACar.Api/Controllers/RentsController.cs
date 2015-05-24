using RentACar.Api.Data;
using RentACar.Api.Models;
using System.Web.Http;

namespace RentACar.Api.Controllers
{
    public class RentsController : ApiController
    {
        private IRepository<Rent> rentRepository;

        public RentsController(IRepository<Rent> rentRepo)
        {
            this.rentRepository = rentRepo;
        }

        [HttpPost]
        public IHttpActionResult Post(Rent model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            this.rentRepository.Add(model);
            this.rentRepository.SaveChanges();

            return Ok(model);
        }
    }
}
