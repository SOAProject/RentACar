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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EarnedMoney" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EarnedMoney.svc or EarnedMoney.svc.cs at the Solution Explorer and start debugging.
    public class EarnedMoney : IEarnedMoney
    {
        private IRepository<Car> carRepository;

        public EarnedMoney()
        {

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
