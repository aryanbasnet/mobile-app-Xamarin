using System.Collections.ObjectModel;
using System.Collections.Generic;
using BookStoreApp.Models;

namespace BookStoreApp.ViewModels
{
    public class HomeViewModel
    {
        public ObservableCollection<Product> Featured { get; } = new ObservableCollection<Product>();

        public HomeViewModel()
        {
            // sample data
            Featured.Add(new Product { Id = 1, Name = "Wireless Headphones", Price = 99.99, ImageUrl = "https://imgs.search.brave.com/NfPwlvphAnOQnZgu9CYCy0yqugjQk72mKH6TU1Zt5mg/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly90My5m/dGNkbi5uZXQvanBn/LzEyLzM5LzE5Lzk2/LzM2MF9GXzEyMzkx/OTk2MzFfdU90cEZN/TVQ5clprQzlYazBR/bXJXUjQ1bWlWaUlC/ekUuanBn", Category = "Electronics", Description = "High quality wireless headphones." });
            Featured.Add(new Product { Id = 2, Name = "Running Shoes", Price = 79.99, ImageUrl = "https://imgs.search.brave.com/DJyUxtD0SweO7Afde7_5ZUonVYBrp-h2XvZZyi-gGdQ/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5pc3RvY2twaG90/by5jb20vaWQvMTQ1/MzgxMDgwNS9waG90/by9ydW5uaW5nLXNo/b2VzLmpwZz9zPTYx/Mng2MTImdz0wJms9/MjAmYz1rTVhXeGhh/WE9oSjhwekFfTnRp/czZENlFvQUg0akhi/VjZET2tPZ2dWSVVN/PQ", Category = "Fashion", Description = "Comfortable running shoes." });
            Featured.Add(new Product { Id = 3, Name = "Coffee Maker", Price = 49.99, ImageUrl = "https://imgs.search.brave.com/DolfNiGuEjjERZYcbIJ9gDZcLA0z_I2t8xkWekWf9jU/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly91cy5l/Y3Njb2ZmZWUuY29t/L2Nkbi9zaG9wL3By/b2R1Y3RzL2J1bm4t/c3BlZWRicmV3LTIu/anBnP3Y9MTU1NzI1/OTE3NSZ3aWR0aD0z/MDA", Category = "Home", Description = "Brew the perfect cup." });
        }
    }
}