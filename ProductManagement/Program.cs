using System;
using System.Collections.Generic;

namespace ProductManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Product Management!");
            List<Product> products = new List<Product>()
            {
                new Product(){ProductID = 1, UserID = 1, Rating = 3.9, Review = "Amazing", isLike = true},
                new Product(){ProductID = 2, UserID = 1, Rating = 3.4, Review = "Good", isLike = false},
                new Product(){ProductID = 3, UserID = 3, Rating = 4.0, Review = "Nice", isLike = false},
                new Product(){ProductID = 4, UserID = 4, Rating = 4.5, Review = "Its Good", isLike = true},
                new Product(){ProductID = 5, UserID = 5, Rating = 5.0, Review = "Amazing", isLike = true},
            };
            foreach(Product p in products)
            {
                Console.WriteLine($"{p.ProductID} {p.UserID} {p.Rating} {p.Review} {p.isLike}");
            }
        }
    }
}
