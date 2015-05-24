namespace RentACar.Api.Models
{
    using System.Collections.Generic;

    public class Car
    {
        public Car()
        {
            this.Rents = new HashSet<Rent>();
        }

        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int YearOfManufacture { get; set; }

        public decimal RentPrice { get; set; }

        public bool IsRented { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
    }
}