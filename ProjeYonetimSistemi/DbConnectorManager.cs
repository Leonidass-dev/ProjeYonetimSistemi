using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace ProjeYönetimSistemi
{
    public static class DbConnectorManager
    {
        private static string GetConnectionString()
        {
            var configConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (!string.IsNullOrWhiteSpace(configConnection))
            {
                return configConnection;
            }
            return "Server=localhost;Database=databaseproje;Uid=root;Pwd=root;";
        }

        /// <summary>
        /// Saklı yordamları (Stored Procedure) çalıştırıp sonuç tablosunu (DataTable) döndürür.
        /// </summary>
        public static DataTable ExecuteStoredProcedure(string storedProcedureName, MySqlParameter[] parameters = null)
        {
            DataTable resultTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        connection.Open();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            resultTable.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DbConnectorManager] Hata: {ex.Message}");
                    throw;
                }
            }

            return resultTable;
        }

        /// <summary>
        /// Sonuç tablosu dönmeyen saklı yordamları (INSERT, UPDATE, DELETE) çalıştırır.
        /// </summary>
        public static void ExecuteStoredProcedureNonQuery(string storedProcedureName, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DbConnectorManager] Hata: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
