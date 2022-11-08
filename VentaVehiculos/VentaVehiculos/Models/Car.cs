﻿namespace VentaVehiculos.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; } 
    }
}