using RentACar.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RentACar.Api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarsService" in both code and config file together.
    [ServiceContract]
    public interface ICarsService
    {
        [OperationContract]
        int GetCarsCount(string param);

        [OperationContract]
        string GetCarsCountInString(string param);

        [OperationContract]
        IEnumerable<string> GetCarsNames();

        [OperationContract]
        IEnumerable<Car> GetCars();

        [OperationContract]
        Car GetCarById(int id);

        [OperationContract]
        int GetCarRentsCountById(int id);

        [OperationContract]
        decimal GetEarnedMoneyByCarId(int id);
    }
}
