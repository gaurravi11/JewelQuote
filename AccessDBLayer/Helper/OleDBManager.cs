using Dapper;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace AccessDBLayer.Helper
{
    public class OleDBManager
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

        public static OleDbConnection getConnection()
        {
            OleDbConnection ConnOleDb = null;
            try
            {
                ConnOleDb = new OleDbConnection(getConnectionString());
                ConnOleDb.Open();
                return (ConnOleDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public static OleDbCommand getCommandSP(string spname)
        {
            OleDbCommand ConnCommand = null;
            try
            {
                ConnCommand = new OleDbCommand(spname);
                ConnCommand.CommandTimeout = 0;
                return (ConnCommand);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public static DataSet GetDataSetwithCommand(OleDbCommand concom)
        {
            OleDbConnection Con = null;
            try
            {
                Con = getConnection();
                concom.Connection = Con;
                OleDbDataAdapter da = new OleDbDataAdapter(concom);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Creating DataSet" + ex);
            }
            finally
            {
                Con.Close();
                Con.Dispose();
            }
        }
        public static OleDbDataReader getReaderSP(OleDbCommand ConnCommand)
        {
            OleDbConnection ConnOleDb = null;
            try
            {
                ConnOleDb = getConnection();
                ConnCommand.Connection = ConnOleDb;
                OleDbDataReader ConnReader = ConnCommand.ExecuteReader(CommandBehavior.CloseConnection);
                return (ConnReader);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public static bool WriteToDbWithoutCommit(OleDbCommand ConnCommand)
        {
            OleDbConnection ConnOleDb = getConnection();
            bool saved = false;
            try
            {
                ConnCommand.Connection = ConnOleDb;
                ConnCommand.ExecuteNonQuery();
                saved = true;
                return (saved);
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
            finally
            {
                ConnCommand.Dispose();
                ConnOleDb.Close();
                ConnOleDb.Dispose();
            }
        }

        public static bool WriteToDbWithoutCommitWithConn(OleDbCommand ConnCommand)
        {
            bool saved = false;
            try
            {
                ConnCommand.ExecuteNonQuery();
                saved = true;
                return (saved);
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
            finally
            {
                ConnCommand.Dispose();
            }
        }

        public static bool WriteToDb(OleDbCommand ConnCommand)
        {
            OleDbConnection ConnOleDb = getConnection();
            OleDbTransaction ConnTransaction = ConnOleDb.BeginTransaction();
            bool saved = false;
            try
            {
                ConnCommand.Connection = ConnOleDb;
                ConnCommand.Transaction = ConnTransaction;
                ConnCommand.ExecuteNonQuery();
                ConnTransaction.Commit();
                saved = true;
                return (saved);
            }
            catch (ApplicationException ex)
            {
                ConnTransaction.Rollback();
                throw new ApplicationException(ex.Message.ToString());
            }
            finally
            {
                ConnCommand.Dispose();
                ConnOleDb.Close();
                ConnOleDb.Dispose();
            }
        }

        public static Int32 WriteToDbwithIdentity(OleDbCommand ConnCommand)
        {
            OleDbConnection ConnOleDb = getConnection();
            OleDbTransaction ConnTransaction = ConnOleDb.BeginTransaction();
            try
            {
                ConnCommand.Connection = ConnOleDb;
                ConnCommand.Transaction = ConnTransaction;
                ConnCommand.ExecuteNonQuery();
                ConnTransaction.Commit();
                ConnCommand.CommandText = "Select @@Identity";
                return (int)ConnCommand.ExecuteScalar();
            }
            catch (ApplicationException ex)
            {
                ConnTransaction.Rollback();
                throw new ApplicationException(ex.Message.ToString());
            }
            finally
            {
                ConnCommand.Dispose();
                ConnOleDb.Close();
                ConnOleDb.Dispose();
            }
        }

        public static Int32 WriteToDbwithIdentityWithConn(OleDbCommand ConnCommand)
        {
            try
            {
                ConnCommand.ExecuteNonQuery();
                ConnCommand.CommandText = "Select @@Identity";
                return (int)ConnCommand.ExecuteScalar();
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
            finally
            {
                ConnCommand.Dispose();
            }
        }

        public static string WriteToDbWithResult(OleDbCommand ConnCommand)
        {
            OleDbConnection ConnOleDb = getConnection();
            OleDbTransaction ConnTransaction = ConnOleDb.BeginTransaction();
            try
            {
                ConnCommand.Connection = ConnOleDb;
                ConnCommand.Transaction = ConnTransaction;
                OleDbParameter prm6 = new OleDbParameter();
                prm6.ParameterName = "@rslt";
                prm6.OleDbType = OleDbType.VarChar;
                prm6.Direction = ParameterDirection.Output;
                prm6.Size = 200;
                ConnCommand.Parameters.Add(prm6);
                ConnCommand.ExecuteNonQuery();
                ConnTransaction.Commit();
                return (ConnCommand.Parameters["@rslt"].Value.ToString());
            }
            catch (Exception ex)
            {
                ConnTransaction.Rollback();
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                ConnCommand.Dispose();
                ConnOleDb.Close();
                ConnOleDb.Dispose();
            }
        }
        public static Int64 WriteToDbWithResultId(OleDbCommand ConnCommand)
        {
            OleDbConnection ConnSql = getConnection();
            OleDbTransaction ConnTransaction = ConnSql.BeginTransaction();
            try
            {
                ConnCommand.Connection = ConnSql;
                ConnCommand.Transaction = ConnTransaction;
                OleDbParameter prm6 = new OleDbParameter();
                prm6.ParameterName = "@rslt";
                prm6.OleDbType = OleDbType.BigInt;
                prm6.Direction = ParameterDirection.Output;
                ConnCommand.Parameters.Add(prm6);
                ConnCommand.ExecuteNonQuery();
                ConnTransaction.Commit();
                return (Convert.ToInt64(ConnCommand.Parameters["@rslt"].Value));
            }
            catch (Exception ex)
            {
                ConnTransaction.Rollback();
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                ConnCommand.Dispose();
                ConnSql.Close();
                ConnSql.Dispose();
            }
        }
    }
}
