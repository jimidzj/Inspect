using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Utility.Database
{

    /// <summary>
    /// The SqlHelper class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of SqlClient.
    /// </summary>
    public abstract class SqlHelper {

        // Read the connection strings from the configuration file
        public static string ConnectionString = Parameter.MES_DATABASE_CONNECTION;

        //Create a hashtable for the parameter cached
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());


        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            return connection;
        }

        public static SqlConnection OpenConnection(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            return connection;
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            // Create a new Oracle command
            SqlCommand cmd = new SqlCommand();

            //Create a connection
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                //Prepare the command
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

                //Execute the command
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExecuteNonQuery(DBInstance db, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            // Create a new Oracle command
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = db.Connection;
            //Prepare the command
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

            //Execute the command
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;

        }

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] commandParameters)
        {
            // Create a new Oracle command
            SqlCommand cmd = new SqlCommand();

            //Create a connection
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                //Prepare the command
                PrepareCommand(cmd, connection, null, CommandType.Text, cmdText, commandParameters);

                //Execute the command
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExecuteNonQuery(DBInstance db, string cmdText, params SqlParameter[] commandParameters)
        {
            // Create a new Oracle command
            SqlCommand cmd = new SqlCommand();

            //Create a connection
            SqlConnection connection = db.Connection;
            //Prepare the command
            PrepareCommand(cmd, connection, db.Transaction , CommandType.Text, cmdText, commandParameters);

            //Execute the command
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;

        }

        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            catch
            {
                throw;
            }
            finally
            {
                //trans.Connection.Close();
            }

        }

         public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            catch
            {
                throw;
            }
            finally
            {
                //connection.Close();
            }
        }

         public static SqlDataReader ExecuteReader(UtilLog log, string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            log.LogInfoWithLevel(connectionString, Log_LoggingLevel.Admin);
            try
            {
                //Prepare the command to execute
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                //Execute the query, stating that the connection should close when the resulting datareader has been read
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                conn.Close();
                throw;
            }
        }

        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                //Prepare the command to execute
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                //Execute the query, stating that the connection should close when the resulting datareader has been read
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                conn.Close();
                throw;
            }
        }

        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] commandParameters)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                //Prepare the command to execute
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, commandParameters);

                //Execute the query, stating that the connection should close when the resulting datareader has been read
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                conn.Close();
                throw;
            }
        }

        public static DataSet ExecuteQuery(string cmdText, params SqlParameter[] commandParameters)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                //Prepare the command to execute
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, commandParameters);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Execute the query, fill dataset
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.Parameters.Clear();
                return ds;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataSet ExecuteQuery(SqlConnection conn, string cmdText, params SqlParameter[] commandParameters)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();
            //  SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                //Prepare the command to execute
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, commandParameters);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Execute the query, fill dataset
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.Parameters.Clear();
                return ds;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                throw;
            }

        }


         public static DataSet ExecuteQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                //Prepare the command to execute
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Execute the query, fill dataset
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.Parameters.Clear();
                return ds;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataSet ExecuteQuery(string connectionString, CommandType cmdType, string cmdText, params ParameterItem[] commandParameters)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                //Prepare the command to execute
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Execute the query, fill dataset
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.Parameters.Clear();
                return ds;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataSet ExecuteQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                //Prepare the command to execute
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Execute the query, fill dataset
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.Parameters.Clear();
                return ds;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataSet ExecuteQuery(string cmdText, ParameterItem[] commandParameters)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                //Prepare the command to execute
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, commandParameters);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Execute the query, fill dataset
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.Parameters.Clear();
                return ds;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataSet ExecuteQuery(string[,] cmdTexts)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                DataSet ds = new DataSet();

                for (int i = 0; i < cmdTexts.GetLength(0); i++)
                {
                    PrepareCommand(cmd, conn, null, CommandType.Text, cmdTexts[i, 0], new SqlParameter[] { });

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);

                    adp.Fill(ds, cmdTexts[i, 1]);

                    cmd.Parameters.Clear();
                }

                return ds;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataSet ExecuteQuery(SqlConnection connection, SqlTransaction transaction, string cmdText, SqlParameter[] commandParameters)
        {

            //Create the command and connection
            SqlCommand cmd = new SqlCommand();

            try
            {
                //Prepare the command to execute
                PrepareCommand(cmd, connection, transaction, CommandType.Text, cmdText, commandParameters);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Execute the query, fill dataset
                DataSet ds = new DataSet();
                adp.Fill(ds);
                ds.AcceptChanges();
                cmd.Parameters.Clear();
                return ds;

            }
            catch
            {

                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                throw;
            }
            finally
            {
                //connection.Close();
            }
        }

        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (transaction == null)
                throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked	or commited, please	provide	an open	transaction.", "transaction");

            // Create a	command	and	prepare	it for execution
            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

            // Execute the command & return	the	results
            object retval = cmd.ExecuteScalar();

            // Detach the SqlParameters	from the command object, so	they can be	used again
            cmd.Parameters.Clear();
            return retval;
        }

         public static object ExecuteScalar(SqlConnection connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connectionString, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            // If the parameters are in the cache
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            // return a copy of the parameters
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] commandParameters)
        {

            //Open the connection if required
            if (conn.State != ConnectionState.Open)
                conn.Open();

            //Set up the command
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            cmd.Transaction = trans;

            //Bind it to the transaction if it exists
            //if (trans != null)
            //    cmd.Transaction = trans;

            // Bind the parameters passed in
            if (commandParameters != null)
            {
                foreach (SqlParameter parm in commandParameters)
                    cmd.Parameters.Add(parm);
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, ParameterItem[] commandParameters)
        {

            //Open the connection if required
            if (conn.State != ConnectionState.Open)
                conn.Open();

            //Set up the command
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            cmd.Transaction = trans;

            //Bind it to the transaction if it exists
            //if (trans != null)
            //    cmd.Transaction = trans;

            // Bind the parameters passed in
            if (commandParameters != null)
            {
                foreach (ParameterItem item in commandParameters)
                {
                    if (item != null)   //ADD BY Andy_liu  2007-3-12 14:33:48 
                    {
                        if (item.ParameterName != null && item.ParameterValue != null)
                        {
                            SqlParameter parm = new SqlParameter(item.ParameterName, item.ParameterValue);
                            cmd.Parameters.Add(parm);
                        }
                    }

                }
            }
        }
    }
}