using System.Web.Http;
using RentACar.Api.Data;
using RentACar.Api.Models;

namespace RentACar.Api.Controllers
{
    public class CarsController : ApiController
    {
        private IRepository<Car> carRepository;

        public CarsController(IRepository<Car> carRepo)
        {
            this.carRepository = carRepo; 
        }

        public IHttpActionResult Get()
        {
            var allCars = this.carRepository.All();

            return Ok(allCars);
        }

        public IHttpActionResult Get(int id)
        {
            var currentCar = this.carRepository.Get(id);

            if (currentCar == null)
            {
                return BadRequest("Car does not exist - invalid id");
            }

            return Ok(currentCar);
        }

        [HttpPost]
        public IHttpActionResult Post(Car model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            this.carRepository.Add(model);
            this.carRepository.SaveChanges();

            return Ok(model);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Car model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCar = this.carRepository.Get(id);
            if (existingCar == null)
            {
                return BadRequest("Car does not exist.");
            }

            existingCar.Brand = model.Brand;
            existingCar.Model = model.Model;
            existingCar.YearOfManufacture = model.YearOfManufacture;
            this.carRepository.Update(existingCar);
            this.carRepository.SaveChanges();

            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var currentCar = this.carRepository.Get(id);
            if (currentCar == null)
            {
                return BadRequest("Invalid Id - no such car existing!");
            }

            this.carRepository.Delete(currentCar);
            this.carRepository.SaveChanges();

            return Ok(currentCar);
        }
    }
}
