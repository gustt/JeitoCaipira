using System;
using System.Collections.Generic;
using System.Text;
using DM.DAL;
using System.Data;
using System.Data.SqlClient;

namespace DM.BLL
{
    public class Categoria : IDataRecord, IDisposable
    {
        private int cdcategoria;
        private string nmcategoria;

        public int Codigo
        {
            get { return cdcategoria; }
        }

        public string Nome
        {
            get { return nmcategoria; }
            set { nmcategoria = value; }
        }

        #region IDataRecord Members

        public int Insert()
        {
            CategoriaPL pl = null;

            try
            {
                pl = new CategoriaPL();
                cdcategoria = pl.stpIncluiCategoria(nmcategoria);
                return cdcategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pl.Dispose();
                pl = null;
            }
        }

        public int Update()
        {
            CategoriaPL pl = null;

            try
            {
                pl = new CategoriaPL();
                return pl.stpAlteraCategoria(cdcategoria, nmcategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pl.Dispose();
                pl = null;
            }
        }

        public int Delete()
        {
            CategoriaPL pl = null;

            try
            {
                pl = new CategoriaPL();
                return pl.stpExcluiCategoria(cdcategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pl.Dispose();
                pl = null;
            }
        }

        public bool IsNew()
        {
            return (cdcategoria == 0);
        }

        #endregion

        #region Métodos de Seleção

        public static Categoria Select(int cdcategoria)
        {
            CategoriaPL pl = null;
            Categoria categoria = null;
            SqlDataReader dr = null;

            try
            {
                pl = new CategoriaPL();
                dr = pl.stpConsultaCategoria(cdcategoria);

                if (dr != null && dr.Read())
                {
                    categoria = new Categoria();
                    categoria.cdcategoria = dr.GetInt32(dr.GetOrdinal("CDCategoria"));
                    categoria.nmcategoria = dr.GetString(dr.GetOrdinal("NMCategoria"));
                }

                return categoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dr != null)
                {
                    if (!dr.IsClosed)
                        dr.Close();
                    dr.Dispose();
                    dr = null;
                }
                if (pl != null)
                {
                    pl.Dispose();
                    pl = null;
                }
            }
        }

        public static DataSet List(string nmcategoria)
        {
            CategoriaPL pl = null;
            DataSet ds = null;

            try
            {
                pl = new CategoriaPL();
                ds = pl.stpConsultaCategoria(nmcategoria);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pl != null)
                {
                    pl.Dispose();
                    pl = null;
                }
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}
