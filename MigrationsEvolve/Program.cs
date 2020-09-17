using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MigrationsEvolve
{
    class Program
    {
        static void Main(string[] args)
        {
            MigrateDatabase();

            Console.ReadKey();
        }

        private static void MigrateDatabase()
        {
            // exclude db/datasets from production and staging environments
            string location = "db/migrations";

            try
            {
                string dbName = "evolve";
                var connectionString = "Server=localhost;Uid=root;Pwd=123456;";
                using (var cnx = new MySqlConnection(connectionString))
                {
                    cnx.Open();
                    using (var cmd = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS {dbName}", cnx))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                using (var cnx = new MySqlConnection($"{connectionString}Database={dbName};"))
                {
                    var evolve = new Evolve.Evolve(cnx)
                    {
                        Locations = new[] { location },
                        IsEraseDisabled = true,
                        Placeholders = new Dictionary<string, string>
                        {
                            ["${table4}"] = "table4"
                        }
                    };

                    evolve.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
