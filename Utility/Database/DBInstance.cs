using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GENLSYS.MES.Common;
using System.Data.SqlClient;

namespace GENLSYS.MES.Utility.Database
{
    public class DBInstance
    {

        /// <summary>
        /// Purpose: Database Connection
        /// Author: Joe
        /// Last Modified Time: 2008/5/3
        /// Last Modified By: Joe
        /// </summary>
        public SqlConnection Connection
        {
            get;
            set;
        }

        /// Purpose: Database Transaction
        /// Author: Joe
        /// Last Modified Time: 2008/5/3
        /// Last Modified By: Joe
        public SqlTransaction Transaction
        {
            get;
            set;
        }

        /// Purpose: Bussiness Transaction ID
        /// Author: George
        /// Last Modified Time: 2009/11/19
        /// Last Modified By: George
        public string BussinessTransactionID  
        {
            get;
            set;
        }

        public DBInstance(string connectionString)
        {
            try
            {
                Connection = SqlHelper.OpenConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   

        /// Purpose: Begin transaction
        /// Author: Joe
        /// Last Modified Time: 2008/5/3
        /// Last Modified By: Joe
        public SqlTransaction BeginTransaction()
        {
            try
            {
                if (!this.IsConnectionOpen())
                {
                    this.Connection.Open();
                }
                Transaction = Connection.BeginTransaction();
                return Transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// Purpose: Begin transaction
        /// Author: George
        /// Last Modified Time: 2009/11/19
        /// Last Modified By: George
        public SqlTransaction BeginTransaction(bool withLog)
        {
            try
            {
                if (!this.IsConnectionOpen())
                {
                    this.Connection.Open();
                }
                Transaction = Connection.BeginTransaction();
                BussinessTransactionID = Function.GetBusinessTransactionID();

                return Transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Commit()
        {
            if (Transaction != null)
                Transaction.Commit();
                BussinessTransactionID = "";
        }

        public void Rollback()
        {
            if (Transaction !=null)
                Transaction.Rollback();
                BussinessTransactionID = "";
        }

        /// <summary>
        /// Purpose: If connection is open then close it
        /// Author: Joe
        /// Last Modified Time: 2008/5/3
        /// Last Modified By: Joe
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                if (IsConnectionOpen())
                    Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsConnectionOpen()
        {
            return (Connection.State == ConnectionState.Open);
        }
    }
}
