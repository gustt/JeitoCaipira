using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBLayers.BLL.Regras
{
    public class Usuario : IDataRecordDBLayers, IDisposable
    {
        public DBLayers.DAL.Entidades.Usuario Instance { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<DBLayers.DAL.Entidades.Usuario> List(string NomeAdministrador)
        {
            UsuarioPL pl = null;
            List<DBLayers.DAL.Entidades.Usuario> retorno = new List<DAL.Entidades.Usuario>();
            try
            {
                pl = new UsuarioPL();
                retorno = 
                    pl.SP_CONSULTAR_USUARIO(NomeAdministrador);
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
            UsuarioPL pl = null;
            try
            {
                pl = new UsuarioPL();
                pl.SP_SALVAR_USUARIO(this.Instance);
                return 0;
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
                using (UsuarioPL pl = new UsuarioPL())
                {
                    pl.SP_DELETAR_USUARIO(this.Instance.UserID);
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
        public static Usuario SelectNewInstance()
        {
            return new Usuario();
        }
        public Usuario Select(string UserID)
        {
            UsuarioPL pl = null;
            try
            {
                pl = new UsuarioPL();
                this.Instance = 
                    pl.SP_SELECIONAR_USUARIO(UserID.ToString(), int.MinValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new Usuario();
        }
        public Usuario Select(int CodigoCliente)
        {
            UsuarioPL pl = null;
            try
            {
                pl = new UsuarioPL();
                this.Instance =
                    pl.SP_SELECIONAR_USUARIO(null, CodigoCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new Usuario();
        }
        public Usuario Select(string UserID, string Password)
        {
            UsuarioPL pl = null;
            try
            {
                pl = new UsuarioPL();
                this.Instance =
                    pl.SP_VALIDA_USUARIO(UserID, Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new Usuario();
        }
    }
}
