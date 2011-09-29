using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBLayers.BLL.Regras
{
    public class Administrador : IDataRecordDBLayers, IDisposable
    {
        public DBLayers.DAL.Entidades.Administrador Instance { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<DBLayers.DAL.Entidades.Administrador> List(string NomeAdministrador)
        {
            AdministradorPL pl = null;
            List<DBLayers.DAL.Entidades.Administrador> retorno = new List<DAL.Entidades.Administrador>();
            try
            {
                pl = new AdministradorPL();
                retorno = 
                    pl.SP_CONSULTAR_ADMINISTRADOR(NomeAdministrador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pl != null)
                    pl.Dispose();
            }
            return retorno;
        }
        public int Insert()
        {
            AdministradorPL pl = null;
            try
            {
                pl = new AdministradorPL();
                return pl.SP_SALVAR_ADMINISTRADOR(this.Instance);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pl != null)
                    GC.SuppressFinalize(pl);
            }
        }
        public int Update()
        {
            throw new NotImplementedException();
        }
        public void Delete()
        {
            try
            {
                using (AdministradorPL pl = new AdministradorPL())
                {
                    pl.SP_DELETAR_ADMINISTRADOR(this.Instance.UserID);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsNew()
        {
            return (this.Instance.UserID == string.Empty);
        }
        public static Administrador SelectNewInstance()
        {
            return new Administrador();
        }
        public Administrador Select(string UserID)
        {
            AdministradorPL pl = null;
            try
            {
                pl = new AdministradorPL();
                this.Instance = 
                    pl.SP_SELECIONAR_ADMINISTRADOR(UserID.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new Administrador();
        }
    }
}
