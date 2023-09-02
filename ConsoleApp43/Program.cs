using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp43
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = DESKTOP-2J3MN6S; Trusted_Connection=True; TrustServerCertificate= True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Добавление 5 продуктов
                for (int i = 6; i <= 10; i++)
                {
                    string insertQuery = "INSERT INTO Products (Name, Description, Price, StockQuantity) " +
                                         "VALUES (@Name, @Description, @Price, @StockQuantity)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Name", $"Product {i}");
                    insertCommand.Parameters.AddWithValue("@Description", $"Description {i}");
                    insertCommand.Parameters.AddWithValue("@Price", i * 5.0);
                    insertCommand.Parameters.AddWithValue("@StockQuantity", i * 10);

                    insertCommand.ExecuteNonQuery();
                }

                // Изменение 5 продуктов (по одному свойству)
                for (int i = 1; i <= 5; i++)
                {
                    string updateQuery = "UPDATE Products SET Price = @Price WHERE ProductID = @ProductID";

                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@Price", i * 7.0);
                    updateCommand.Parameters.AddWithValue("@ProductID", i);

                    updateCommand.ExecuteNonQuery();
                }

                Console.WriteLine("Продукты успешно добавлены и изменены.");
            }
        }
    }
}