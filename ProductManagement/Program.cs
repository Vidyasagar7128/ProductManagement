using System;
using System.Collections.Generic;
using System.Linq;
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
                new Product(){ProductID = 4, UserID = 4, Rating = 2.9, Review = "Its Good", isLike = true},
                new Product(){ProductID = 5, UserID = 5, Rating = 5.0, Review = "Amazing", isLike = true},
                new Product(){ProductID = 6, UserID = 6, Rating = 3.9, Review = "Amazing", isLike = true},
                new Product(){ProductID = 7, UserID = 3, Rating = 3.4, Review = "Good", isLike = false},
                new Product(){ProductID = 8, UserID = 8, Rating = 4.0, Review = "Nice", isLike = false},
                new Product(){ProductID = 9, UserID = 10, Rating = 4.5, Review = "Its Good", isLike = true},
                new Product(){ProductID = 10, UserID = 9, Rating = 5.0, Review = "Amazing", isLike = true},
            };
            var topThree = (from pro in products
                                where pro.Rating > 3.0 && pro.ProductID == 1 || pro.Rating > 3.0 && pro.ProductID == 4 || pro.Rating > 3.0 && pro.ProductID == 9
                            orderby pro.Rating descending
                                select pro);

            foreach (var p in topThree)
            {
                Console.WriteLine($"{p.ProductID} {p.UserID} {p.Rating} {p.Review} {p.isLike}");
            }
        }
    }
}
