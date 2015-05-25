using RentACar.Api.Data;
using RentACar.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RentACar.Api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CarsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CarsService.svc or CarsService.svc.cs at the Solution Explorer and start debugging.
    public class CarsService : ICarsService
    {
        private IRepository<Car> carRepository;

        public CarsService()
        {

        }

        public int GetCarsCount(string param)
        {
            var dbContext = new RentACarDbContext();
            this.carRepository = new EFRepository<Car>(dbContext);

            var carsCount = this.carRepository
                .All()
                .Count();

            return carsCount;
        }

        public string GetCarsCountInString(string param)
        {
            var dbContext = new RentACarDbContext();
            this.carRepository = new EFRepository<Car>(dbContext);

            var carsCount = this.carRepository
                .All()
                .Count();

            return carsCount.ToString();
        }
    }
}
