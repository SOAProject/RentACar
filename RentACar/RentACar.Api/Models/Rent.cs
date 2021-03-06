﻿using System;
namespace RentACar.Api.Models
{
    public class Rent
    {
        public int Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}