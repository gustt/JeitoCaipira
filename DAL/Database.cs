using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DM.DAL
{
    public class Database : IDisposable
    {

        public enum Action { Select, List, Insert, Update, Delete }

        SqlConnection con = null;
        SqlTransaction trans = null;

        #region IDisposable Members

        public void Dispose()
        {
            if (trans != null)
            {
                trans.Dispose();
                trans = null;
            }
            if (con != null)
                CloseConnection();
        }

        #endregion

        #region Métodos manipuladores da conexão

        private SqlConnection GetConnection()
        {
            string strConexao = @"Data Source=MCRINST01\SQLEXPRESS;Initial Catalog=CesaiNet;Integrated Security=True;";
            return new SqlConnection(strConexao);
        }

        private void OpenConnection()
        {
            try
            {
                if (con == null)
                    con = GetConnection();
                if (con.State != ConnectionState.Open)
                    con.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void CloseConnection()
        {
            if (con != null)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                con.Dispose();
                con = null;
            }
        }

        #endregion

        public int ExecuteNonQuery(string strProcedureName)
        {
            Queue<SqlParameter> qParameters = null;
            return ExecuteNonQuery(strProcedureName, ref qParameters);
        }

        public int ExecuteNonQuery(string strProcedureName, ref Queue<SqlParameter> qParameters)
        {
            SqlTransaction nullTransaction = null;
            return ExecuteNonQuery(strProcedureName, ref qParameters, ref nullTransaction);
        }

        public int ExecuteNonQuery(string strProcedureName, ref Queue<SqlParameter> qParameters, 
            ref SqlTransaction trans)
        {
            bool externTrans = (trans != null);
            SqlCommand cmd = null;
            SqlParameter parameter = null;

            if (externTrans)
            {
                this.con = trans.Connection;
                this.trans = trans;
            }
            else if (this.con == null)
                this.con = GetConnection();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = strProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.con;

                while (qParameters != null && qParameters.Count > 0)
                    cmd.Parameters.Add(qParameters.Dequeue());

                parameter = new SqlParameter();
                parameter.ParameterName = "@ReturnValue";
                parameter.Direction = ParameterDirection.ReturnValue;
                parameter.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(parameter);

                OpenConnection();

                if (this.trans == null)
                    this.trans = this.con.BeginTransaction(IsolationLevel.Serializable);

                cmd.Transaction = this.trans;
                
                cmd.ExecuteNonQuery();
                if (!externTrans)
                    this.trans.Commit();

                return (int)parameter.Value;
            }
            catch (Exception ex)
            {
                if (!externTrans && this.trans != null)
                    this.trans.Rollback();
                throw ex;
            }
            finally
            {
                if (parameter != null)
                    parameter = null;
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        public SqlDataReader ExecuteDataReader(string strProcedureName)
        {
            Queue<SqlParameter> qParameters = null;
            return ExecuteDataReader(strProcedureName, ref qParameters);
        }

        public SqlDataReader ExecuteDataReader(string strProcedureName, ref Queue<SqlParameter> qParameters) 
        {
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            if (this.con == null)
                con = GetConnection();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = strProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.con;

                while (qParameters != null && qParameters.Count > 0)
                    cmd.Parameters.Add(qParameters.Dequeue());

                OpenConnection();

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                
                return reader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        public DataSet ExecuteDataSet(string strProcedureName)
        {
            Queue<SqlParameter> qParameters = null;
            return ExecuteDataSet(strProcedureName, ref qParameters);
        }

        public DataSet ExecuteDataSet(string strProcedureName, ref Queue<SqlParameter> qParameters)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataSet ds = null;

            if (this.con == null)
                this.con = GetConnection();

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = strProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.con;

                while (qParameters != null && qParameters.Count > 0)
                    cmd.Parameters.Add(qParameters.Dequeue());

                da = new SqlDataAdapter(cmd);
                ds = new DataSet();

                OpenConnection();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }
            }
        }
    }
}
