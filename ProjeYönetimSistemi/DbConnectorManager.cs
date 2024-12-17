using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using ProjeYönetimSistemi;

namespace ProjeYönetimSistemi
{
    public static class DbConnectorManager
    {
       
        private static string connectionString = "Server=localhost;Database=databaseproje;Uid=root;Pwd=2003;";

        // Saklı yordamları çalıştırmak için metod
        public static DataTable ExecuteStoredProcedure(string storedProcedureName, MySqlParameter[] parameters = null)
        {
            DataTable resultTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parametreleri ekle
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
                    Console.WriteLine($"Hata: {ex.Message}");
                }
            }

            return resultTable;
        }

        // Saklı yordamı sadece veri alıp yazmak için kullanabileceğiniz bir versiyon
        public static void ExecuteStoredProcedureNonQuery(string storedProcedureName, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parametreleri ekle
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        // Veritabanı bağlantısını aç
                        connection.Open();

                        // Saklı yordamı çalıştır (sonuç dönmeyen işlemler için)
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }
            }
        }

        



    }
}
