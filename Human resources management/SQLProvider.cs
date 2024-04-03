using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Human_resources_management
{
    internal class SQLProvider : IDisposable
    {
        private static string ConnectionString = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
        public SqlConnection instance { get; }
        public static SQLProvider Connect(string connectionString = null)
        {
            if (connectionString != null)
                ConnectionString = connectionString;
            try
            {
                SQLProvider provider = new SQLProvider(ConnectionString);
                provider.instance.Open();
                return provider;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
        public int ExecCommand(string command, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (var cmd = new SqlCommand(command, this.instance))
                {
                    foreach (var kvp in parameters)
                    {
                        cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        public DataSet ExecQuery(string query, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (var command = new SqlCommand(query, this.instance))
                {
                    foreach (var kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        return dataSet;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
        public DataSet ExecQuery(string query, string srcTable, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (var command = new SqlCommand(query, this.instance))
                {
                    foreach (var kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, srcTable);
                        return dataSet;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
        private SQLProvider(string connection)
        {
            this.instance = new SqlConnection(ConnectionString);
        }
        public void Dispose()
        {
            this.instance.Close();
            GC.SuppressFinalize(this);
        }
    }
}
