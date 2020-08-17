using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessDBLayer.Helper
{
    public class DapperOleDBManager
    {
        private static string getConnectionString()
        {
            try
            {
                return (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\JewelData.mdb;");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public static object ExecuteScalar(string query, DynamicParameters parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(getConnectionString()))
            {
                conn.Open();
                var result = conn.ExecuteScalar(query, parameters);
                conn.Close();
                return result;
            }
        }
        public static T GetSingleObject<T>(string query, DynamicParameters parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(getConnectionString()))
            {
                conn.Open();
                var result = conn.QueryFirstOrDefault<T>(query, parameters);
                conn.Close();
                return result;
            }
        }

        public static IEnumerable<T> GetListObject<T>(string query, DynamicParameters parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(getConnectionString()))
            {
                conn.Open();
                var result = conn.Query<T>(query, parameters);
                conn.Close();
                return result;
            }
        }

        public static async Task<IEnumerable<T>> GetListObjectAsync<T>(string query, DynamicParameters parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(getConnectionString()))
            {
                conn.Open();
                var result = await conn.QueryAsync<T>(query, parameters);
                conn.Close();
                return result;
            }
        }

        public static bool WriteToDb(string query, DynamicParameters parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(getConnectionString()))
            {
                conn.Open();
                var result = conn.Execute(query, parameters);
                conn.Close();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public static Int32 WriteToDbwithIdentity(string query, DynamicParameters parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(getConnectionString()))
            {
                conn.Open();
                var result = conn.Execute(query, parameters);
                if (result > 0)
                {
                    result = (Int32)conn.ExecuteScalar("Select @@Identity");
                }
                conn.Close();
                return result;
            }
        }
    }
}
