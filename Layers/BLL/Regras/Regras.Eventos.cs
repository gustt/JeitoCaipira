using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBLayers.BLL.Regras
{
    public class Eventos : IDataRecordDBLayers, IDisposable
    {
        public DAL.Entidades.Eventos Instance { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<DAL.Entidades.Eventos> List()
        {
            EventosPL pl = null;
            List<DAL.Entidades.Eventos> retorno = new List<DAL.Entidades.Eventos>();
            try
            {
                pl = new EventosPL();
                retorno = 
                    pl.SP_CONSULTAR_EVENTOS();
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
            EventosPL pl = null;
            try
            {
                pl = new EventosPL();
                return pl.SP_SALVAR_EVENTOS(this.Instance);
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
                using (EventosPL pl = new EventosPL())
                {
                    pl.SP_EXCLUIR_EVENTOS(this.Instance.Codigo);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsNew()
        {
            return (this.Instance.Codigo == 0);
        }
        public static Eventos SelectNewInstance()
        {
            return new Eventos();
        }
        public void Select(int Codigo)
        {
            EventosPL pl = null;
            try
            {
                pl = new EventosPL();
                this.Instance = pl.SP_SELECIONAR_EVENTOS(Codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
