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

        public IEnumerable<string> GetCarsNames()
        {
            var dbContext = new RentACarDbContext();
            this.carRepository = new EFRepository<Car>(dbContext);

            var carsNames = this.carRepository
                .All()
                .Select(car => car.Model)
                .Distinct()
                .ToArray();

            return carsNames;
        }

        public int GetCarRentsCountById(int id)
        {
            var dbContext = new RentACarDbContext();
            this.carRepository = new EFRepository<Car>(dbContext);

            var rentsCount = this.carRepository
                .Get(id)
                .Rents
                .Count();

            return rentsCount;
        }

        public decimal GetEarnedMoneyByCarId(int id)
        {
            var dbContext = new RentACarDbContext();
            this.carRepository = new EFRepository<Car>(dbContext);

            var car = this.carRepository
                .Get(id);

            if (car != null)
            {
                var totalDays = car.Rents.Sum(m => (m.To - m.From).TotalDays);
                var earnedMoney = (decimal)totalDays * car.RentPrice;

                return earnedMoney;
            }

            return 0;
        }
    }
}
