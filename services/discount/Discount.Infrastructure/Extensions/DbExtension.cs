using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Extensions
{
    public static class DbExtension
    {
        public static IHost MigrateDatabase<TContext>(this IHost host)
        {
            using (var scope = host.Services.CreateAsyncScope()){
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();
                try
                {
                    logger.LogInformation("Discount DB Migration started.");
                    ApplyMigrations(config);
                    logger.LogInformation("Discount DB Migration completed.");
                }
                catch(Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
            return host;
        }

        private static async Task ApplyMigrations(IConfiguration config)
        {
            var retryCounts = 5;
            while (retryCounts > 0)
            {
                try
                {
                    using var connection = new NpgsqlConnection(config.GetValue<string>("DatabaseSettings:ConnectionString"));
                    await connection.OpenAsync();
                    using var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };
                    command.CommandText = "Drop table if exists Coupon";
                    command.ExecuteNonQuery();
                    command.CommandText = @"Create table Coupon (Id serial primary key, ProductName varchar(500) not null, Description text, Amount int)";
                    command.ExecuteNonQuery();
                    command.CommandText = "Insert into Coupon (ProductName, Description, Amount) Values ('Egypt Adidas Quick Force Indoor Badminton Shoes', 'Adidas Discount', 600)";
                    command.ExecuteNonQuery();
                    command.CommandText = "Insert into Coupon (ProductName, Description, Amount) Values ('PowerFit 19 FH Rubber Spike Cricket Shoes', 'Nike Discount', 700)";
                    command.ExecuteNonQuery();
                    break;
                }
                catch (Exception ex)
                {
                    retryCounts--;
                    Console.WriteLine($"An error occurred while migrating the database. Retrying... {retryCounts} attempts left. Error: {ex.Message}");
                    if (retryCounts == 0)
                    {
                        Console.WriteLine("Failed to migrate the database after multiple attempts. Please check the connection and try again later.");
                        throw;
                    }
                    await Task.Delay(2000);
                }
            }
        }
    }
}
