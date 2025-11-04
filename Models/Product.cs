using System;
using System.Collections.Generic;

namespace BookStoreApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
        public string Category { get; set; }
        public double Rating { get; set; }
    }
}