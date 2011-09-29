using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DM.DAL
{
    public class CategoriaPL : IDisposable
    {
        public SqlDataReader stpConsultaCategoria(int cdcategoria)
        {
            Queue<SqlParameter> qParameters = null;
            Database db = null;
            SqlDataReader dr = null;

            try
            {
                CreateParameters(Database.Action.Select, ref qParameters, cdcategoria, string.Empty);
                db = new Database();
                dr = db.ExecuteDataReader("stpConsultaCategoria", ref qParameters);
                return dr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                qParameters = null;
            }
        }

        public DataSet stpConsultaCategoria(string nmcategoria)
        {
            Queue<SqlParameter> qParameters = null;
            Database db = null;
            DataSet ds = null;

            try
            {
                CreateParameters(Database.Action.List, ref qParameters, 0, nmcategoria);
                db = new Database();
                ds = db.ExecuteDataSet("stpConsultaCategoria", ref qParameters);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                qParameters = null;
                db.Dispose();
                db = null;
            }
        }

        public int stpIncluiCategoria(string nmcategoria)
        {
            Queue<SqlParameter> qParameters = null;
            Database db = null;

            try
            {
                CreateParameters(Database.Action.Insert, ref qParameters, 0, nmcategoria);
                db = new Database();
                return db.ExecuteNonQuery("stpIncluiCategoria", ref qParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                qParameters = null;
                db.Dispose();
                db = null;
            }
        }

        public int stpAlteraCategoria(int cdcategoria, string nmcategoria)
        {
            Queue<SqlParameter> qParameters = null;
            Database db = null;

            try
            {
                CreateParameters(Database.Action.Update, ref qParameters, cdcategoria, nmcategoria);
                db = new Database();
                return db.ExecuteNonQuery("stpAlteraCategoria", ref qParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                qParameters = null;
                db.Dispose();
                db = null;
            }
        }

        public int stpExcluiCategoria(int cdcategoria)
        {
            Queue<SqlParameter> qParameters = null;
            Database db = null;

            try
            {
                CreateParameters(Database.Action.Delete, ref qParameters, cdcategoria, string.Empty);
                db = new Database();
                return db.ExecuteNonQuery("stpExcluiCategoria", ref qParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                qParameters = null;
                db.Dispose();
                db = null;
            }
        }

        #region Criação de Parâmetros

        private int CreateParameters(Database.Action action, ref Queue<SqlParameter> qParameters, int cdcategoria, string nmcategoria)
        {
            SqlParameter parameter = null;
            qParameters = new Queue<SqlParameter>();

            if (action == Database.Action.Select ||
                action == Database.Action.Update ||
                action == Database.Action.Delete)
            {
                parameter = new SqlParameter();
                parameter.ParameterName = "@CDCategoria";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Size = 4;
                parameter.Value = cdcategoria;
                qParameters.Enqueue(parameter);
            }

            if (action == Database.Action.List ||
                action == Database.Action.Update ||
                action == Database.Action.Insert)
            {
                parameter = new SqlParameter();
                parameter.ParameterName = "@NMCategoria";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Size = 50;
                parameter.Value = nmcategoria;
                qParameters.Enqueue(parameter);
            }

            return qParameters.Count;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            
        }

        #endregion
    }
}
