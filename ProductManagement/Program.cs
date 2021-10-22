using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace ProductManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Product Management!");
           List<Product> products = new List<Product>();
            int count = 0;
            bool likes = false;
            string[] productReviews = { "Amazing", "Good",  "Nice", "Its Good", "Fine", "Not Bad", ";)", "Cool", null, "Just Ok", "Great", null, "Good", "Nice", "Its Good", "Fine", "Not Bad", "Amazing Product", "Bad Product", "Good Quality", "Cool", "Just Ok", "Great", "Amazing Quality", "Good Product" };
            double[] rate = { 4.5, 4.5, 3.9, 4.8, 4.9, 5.0, 1.4, 3.2, 4.8, 3.9, 3.5, 1.8, 4.9, 5.0, 2.9, 2.2, 1.0, 3.0, 4.8, 4.1, 2.3, 1.9, 4.9, 2.0, 5.0 };
            for (int i = 0; i < 25; i++)
            {
                int uId = new Random().Next(1, 26);
                int like = new Random().Next(0,2);
                if (like == 0)
                    likes = true;
                else
                    likes = false;
               Product pd = new Product() { ProductID = i+1, UserID = uId, Rating = rate[i], Review = productReviews[i], isLike = likes };
                products.Add(pd);
            }
            ///Top 3 Reviews 
            var topThree = (from pro in products
                                where pro.Rating > 3.0 && pro.ProductID == 1 || pro.Rating > 3.0 && pro.ProductID == 4 || pro.Rating > 3.0 && pro.ProductID == 9
                            orderby pro.Rating descending
                                select pro);
            foreach (var p in topThree)
            {
                Console.WriteLine($"{p.ProductID} {p.UserID} {p.Rating} {p.Review} {p.isLike}");
            }
            ///UC4 UC5 : reviews Count
            ///UC7 : Retriving ProductId & Reviews
            var reviewCounts = (
                from size in products
                    orderby size.Review
                    select size);
            foreach (var i in reviewCounts)
            {
                if (i.Review != null)
                {
                    count++;
                    Console.WriteLine($"ProductId: {i.ProductID} Review: {i.Review}");
                }
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"{count} Reviews by Users");
            Console.WriteLine("---------------------------------------");
            ///UC6 : Skip top 5 Records from List
            var skipRecords = (
                from data in products
                    orderby data.Rating descending
                    select data).Skip(6);
            foreach (var i in skipRecords)
            {
                    Console.WriteLine($"ProductId: {i.ProductID} Review: {i.Rating}");
            }
            ///UC8 Create DataTable & Adding values in it
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ProductId",typeof(int));
            dataTable.Columns.Add("UserId", typeof(int));
            dataTable.Columns.Add("Rating", typeof(double));
            dataTable.Columns.Add("Reviews", typeof(string));
            dataTable.Columns.Add("Likes", typeof(bool));

            for (int i = 0; i < 25; i++)
            {
                DataRow row = dataTable.NewRow();
                int uId = new Random().Next(1, 26);
                int like = new Random().Next(0, 2);
                if (like == 0)
                    likes = true;
                else
                    likes = false;
                row["ProductId"] = i + 1;
                row["UserId"] = uId;
                row["Rating"] = rate[i];
                row["Reviews"] = productReviews[i];
                row["Likes"] = likes;
                dataTable.Rows.Add(row);
            }
            //Showing All records
            var table = (
                         from DataRow row in dataTable.Rows
                         where row.Field<bool>("Likes") == true
                         select row
                         );
            foreach (DataRow r in table)
            {
                Console.WriteLine($" DataTable: {r["ProductId"]} {r["UserId"]} {r["Rating"]} {r["Reviews"]} {r["Likes"]}");
            }
            ///Showing Rating Average
            var ratingTable = (
                         from DataRow row in dataTable.Rows
                         select row
                         );
            foreach (DataRow r in ratingTable)
            {
                var avg = (
                         dataTable.AsEnumerable().Average(a => r.Field<double>("Rating"))
                      );
                Console.WriteLine($"{avg}");
            }
            
        }
    }
}
