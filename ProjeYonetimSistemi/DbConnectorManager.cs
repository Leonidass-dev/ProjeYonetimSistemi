using System;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace ProjeYönetimSistemi
{
    /// <summary>
    /// MySQL veritabanı bağlantısı ve saklı yordam (Stored Procedure) operasyonlarını
    /// yöneten merkezi veri erişim katmanı yöneticisi.
    /// </summary>
    public static class DbConnectorManager
    {
        /// <summary>
        /// App.config içerisinden bağlantı dizesini okur, yapılandırılmamışsa varsayılan yerel bağlantıyı döndürür.
        /// </summary>
        public static string GetConnectionString()
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

        /// <summary>
        /// Tekil değer (COUNT, MAX, ID vb.) döndüren saklı yordamları çalıştırır.
        /// </summary>
        public static object ExecuteStoredProcedureScalar(string storedProcedureName, MySqlParameter[] parameters = null)
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
                        return command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DbConnectorManager] Hata: {ex.Message}");
                    throw;
                }
            }
        }

        /// <summary>
        /// Düz metin parolaları SHA-256 algoritmasıyla güvenli bir şekilde özetler (hashing).
        /// </summary>
        public static string HashPassword(string rawPassword)
        {
            if (string.IsNullOrEmpty(rawPassword))
            {
                return string.Empty;
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
